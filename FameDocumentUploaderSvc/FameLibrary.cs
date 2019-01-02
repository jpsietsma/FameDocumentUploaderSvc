using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Timers;
using FameDocumentUploaderSvc.Models;

namespace FameDocumentUploaderSvc
{
    public static class FameLibrary
    {
        #region Development Methods

            //Display console output during testing
            public static void ShowVerboseOutput(bool useVerbose, string filename, string changetype, string filepath)
            {
                if (useVerbose)
                {
                    Console.WriteLine(filename + " has been " + changetype + " to FAME.  Database has been updated. ");
                    Console.WriteLine(filepath);
                    Console.WriteLine();
                }                                  
            }

        #endregion

        #region Logging Method Definitions...

            //logs event to the Windows Event Log as event type information
            /// <summary>
            /// Logs an event to the windows event log as a notification type
            /// </summary>
            /// <param name="message">Message to write to the event log</param>
            public static void LogWindowsEvent(string message)
            {
                string eventSource = "FAME Document Upload Watcher";
                DateTime dt = new DateTime();
                dt = System.DateTime.UtcNow;
                message = dt.ToLocalTime() + ": " + message;

                EventLog.WriteEntry(eventSource, message);
            }

            //logs event to the windows event log as supplied specific event type
            /// <summary>
            /// Logs an event to the windows event log as the specified event type
            /// </summary>
            /// <param name="message">Message to write to the event log</param>
            /// <param name="e">EventLogEntryType to determine log entry type</param>
            public static void LogWindowsEvent(string message, EventLogEntryType e)
            {
                string eventSource = "FAME Document Upload Watcher";
                DateTime dt = new DateTime();
                dt = DateTime.UtcNow;
                message = dt.ToLocalTime() + ": " + message;

                EventLog.WriteEntry(eventSource, message, e);
            }

            //Writes to specified FAME log, supplied message
            /// <summary>
            /// Write to a specific FAME document uploader log with a specific message
            /// </summary>
            /// <param name="logType">Type of log to write</param>
            /// <param name="msg">Message to write to newly added log</param>
            public static void WriteFameLog(string logType, string msg)
            {
                string message = DateTime.Now.ToString(@"HH:mm:sstt - ");
                string logTypePath = null;

                message += msg;

                CheckLogFiles(logType);

                switch (logType)
                {

                    case "error": {

                            logTypePath = Configuration.errorLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log";

                            LogWindowsEvent(message, EventLogEntryType.Error);

                            break;
                    }
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(logTypePath, true))
                {
                    file.WriteLine(message);
                }

            }

            //Write to the FAME uploader program logs, using specific log types
            /// <summary>
            /// Write to a particular type of FAME document uploader log
            /// </summary>
            /// <param name="arg">FileSystemEventArgs dropped file object</param>
            /// <param name="logType">Type of log to write to</param>
            /// <param name="errSub">Error subject type, ie: error, notice, status</param>
            /// <param name="addmsg">Message to add to the newly written log</param>
            public static void WriteFameLog(FileSystemEventArgs arg, string logType, string errSub = "notice", string addmsg = "")
            {

                DateTime dt = new DateTime();
                dt = System.DateTime.UtcNow;
                string message = dt.ToLocalTime().ToString(@"HH:mm:sstt") + " - ";

                switch (logType)
                {
                    case "error":
                        {
                            CheckLogFiles("error");

                            if (errSub == "invalidFarmIDorContractor")
                            {
                                using (StreamWriter file = new StreamWriter(Configuration.errorLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log", true))
                                {
                                    message += "Invalid Farm ID or Contractor - " + (arg.Name).Split('_')[1] + " - upload cancelled.";
                                    file.WriteLine(message);
                                                                    
                                }

                                LogWindowsEvent(message, EventLogEntryType.Warning);

                            }
                            else if (errSub == "invalidDocType")
                            {
                                using (StreamWriter file = new StreamWriter(Configuration.errorLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log", true))
                                {
                                    message += "Invalid Document Type - " + (arg.Name).Split('_')[0] + " - upload cancelled.";
                                    file.WriteLine(message);
                                                                    
                                }

                                LogWindowsEvent(message, EventLogEntryType.Warning);
                            }                                                       

                            break;
                        }
                    case "notice":
                        {
                            CheckLogFiles("transfer");

                            using (StreamWriter file = new StreamWriter(Configuration.transferLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_transfer.log", true))
                            {
                                message += addmsg;
                                file.WriteLine(message);
                                                            
                            }

                            LogWindowsEvent(message);

                            break;
                        }
                    case "status":
                        {
                            CheckLogFiles("system");

                            using (StreamWriter file = new StreamWriter(Configuration.sysLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log", true))
                            {
                                message += addmsg;
                                file.WriteLine(message);
                                                            
                            }

                            LogWindowsEvent(message);

                            break;
                        }
                }
            }

            //Writes to the FAME uploader system log
            /// <summary>
            /// Writes to the FAME document uploader system log
            /// </summary>
            /// <param name="msg">Message to attach to the log</param>
            public static void WriteFameLog(string msg)
            {
                string message = DateTime.Now.ToString(@"HH:mm:sstt");
                message += msg;

                CheckLogFiles("system");
                using (StreamWriter file = new StreamWriter(Configuration.sysLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log", true))
                {   
                    file.WriteLine(message);
                    file.Close();
                }

                LogWindowsEvent(message);

            }

            //Check to make sure each of our error log files exist, or create them if they don't.  Write event to event log to record this, also.
            /// <summary>
            /// Check and create daily error log files if they dont exist.  Writes log notification when creating new files.
            /// </summary>
            /// <param name="logType">Type of log to check, ie: error, transfer, or system</param>
            public static void CheckLogFiles(string logType)
            {
                if (logType == "error")
                {
                    if (!File.Exists(Configuration.errorLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log"))
                    {
                        using (FileStream fs = File.Create(Configuration.errorLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log"))
                        {
                            
                        }

                        WriteFameLog(" - Daily Error Log Does not exist, the file has been created");
                    }
                }

                if (logType == "transfer")
                {
                    if (!File.Exists(Configuration.transferLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_transfer.log"))
                    {
                        using (FileStream fs = File.Create(Configuration.transferLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_transfer.log"))
                        {
                            
                        }

                        WriteFameLog(" - Daily transfer Log Does not exist, the file has been created.");
                    }
                }

                if (logType == "system")
                {
                    if (!File.Exists(Configuration.sysLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log"))
                    {
                        using (FileStream fs = File.Create(Configuration.sysLogPath + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log"))
                        {
                            
                        }

                        WriteFameLog(" - Daily System Log Does not exist, the file has been created.");
                    }
                }
            }

        #endregion

        #region Data Access Methods...

            //Get the pk_farmBusiness by providing the corresponding Farm ID
            /// <summary>
            /// Get pk_farmBusiness for associated farm
            /// </summary>
            /// <param name="farmID">Farm ID </param>
            /// <returns></returns>
            public static int GetFarmBusinessByFarmId(string farmID)
            {
                int pk_FarmBusiness = 0;

                using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
                {

                    try
                    {
                        cnn.Open();
                        SqlCommand sql = new SqlCommand($@"SELECT pk_farmBusiness FROM dbo.farmBusiness WHERE farmID = '{ farmID }'", cnn);
                        Int32 pkFarmBusiness = (Int32)sql.ExecuteScalar();
                        pk_FarmBusiness = pkFarmBusiness;


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }

                return pk_FarmBusiness;

            }

            //Get farmID by pk_farmBusiness
            /// <summary>
            /// Return the Farm ID for the farm of the provided pk_farmBusiness
            /// </summary>
            /// <param name="uFarmBusiness">pk_FarmBusiness of Farm which to retrieve FarmID</param>
            /// <returns>string representing the FarmID</returns>
            public static string GetFarmIdByFarmBusiness(int uFarmBusiness)
            {
                string finalFarmID = string.Empty;

                using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
                {

                    try
                    {
                        cnn.Open();
                        SqlCommand sql = new SqlCommand($@"SELECT farmID FROM dbo.farmBusiness WHERE pk_farmBusiness = '{ uFarmBusiness }' ", cnn);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh, an error occurred!: " + e.Message);
                    }

                }

                return finalFarmID;
            }

            //Get the pk_FarmBusiness for the contractor associated with a document by the provided document prefix
            /// <summary>
            /// Return the pk_participant for the contractor with the provided contractorPrefix (contractor name)
            /// </summary>
            /// <param name="contractorPrefix">string contractor prefix to document name</param>
            /// <returns>INT representing the pk_FarmBusiness of the associated contractor</returns>
            public static int GetParticipantIDFromContractor(string contractorPrefix)
            {
                int finalParticipantID = 0;

                using (SqlConnection conn = new SqlConnection(Configuration.connectionString))
                {
                    conn.Open();
                    string baseQuery = $@"SELECT fullname_FL_dnd FROM dbo.participant WHERE fullname_FL_dnd LIKE '%{ contractorPrefix }%' ";

                    //Create our sql command object and set the command text and connection context
                    SqlCommand sqlQuery = new SqlCommand(baseQuery, conn);

                    //Execute our query and count the results, numRows will be 0 for invalid contractor
                    int.TryParse(sqlQuery.ExecuteNonQuery().ToString(), out int numRows);

                    //Show us an error if the contractor name is not recognized and do not upload the file
                    //Otherwise get the participant ID from the database
                    if (numRows == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Unrecognized contractor name.  Please check the file name and try again.");
                        Console.WriteLine();

                        return numRows;
                    }
                    else
                    {

                        baseQuery = $@"SELECT pk_participant FROM dbo.participant WHERE fullname_FL_dnd = '{ contractorPrefix }'";
                        sqlQuery = new SqlCommand(baseQuery, conn);

                        //get our participant id result from the query and parse it as an INT and set equal with finalParticipantID
                        var participantID = sqlQuery.ExecuteScalar();
                        int.TryParse(participantID.ToString(), out finalParticipantID);

                        Console.WriteLine();
                        Console.WriteLine($"Participant ID: { finalParticipantID }");
                        Console.WriteLine();

                    }
                }

                return finalParticipantID;
            }

            //Determines the uploader of the file by checking Windows Security event log entries
            /// <summary>
            /// Determine the windows username of the user that uploaded the document
            /// </summary>
            /// <param name="message"></param>
            /// <param name="fileName">Name of uploaded file to search</param>
            /// <returns>string username of file drop user</returns>
            public static string GetUploadUserName(string message, string fileName)
            {
                string finalUserName = message;
                string finalUserDomain = @"WAC\";

                Regex regexPattern = new Regex(@"Account Name:\s*(?<userName>.*)\n");
                Match match = regexPattern.Match(message);

                string finalMessage = finalUserDomain + match.Groups["userName"];

                return finalMessage;
            }

        #endregion

        #region Email Configuration Methods...

            //Sends a notification email to uploader when a duplicate file upload is attempted
            /// <summary>
            /// Send notification email when duplicate file upload is attempted
            /// </summary>
            /// <param name="arg">FileSystemWatcher event to email about</param>
            /// <param name="uFinalPath">Final path to the uploaded file</param>
            /// <param name="uDocUploadTime">Time document was uploaded</param>
            /// <param name="mailType">Type of email to send (single vs multiple files)</param>
            /// <param name="username">Email Address to send notification to</param>
            /// <returns>true or false on success or fail of sending email</returns>
            public static bool SendUploadedFileEmail(FileSystemEventArgs arg, string uFinalPath, DateTime uDocUploadTime, bool wasSuccessful = true, string errorMessage = null, string mailType = "single", string username = @"jsietsma@nycwatershed.org")
            {
                bool sendSuccess = true;

                //If enabled, build and sent failure email
                if (ConfigurationManager.AppSettings["EnableUploadEmails"] == "true")
                {                
                    string mailRecipient = username;

                    SmtpClient smtp = new SmtpClient(Configuration.smtpHost, Configuration.smtpPort)
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(Configuration.smtpUser, Configuration.smtpPass),
                        Host = Configuration.smtpHost,
                        EnableSsl = false,
                        Port = Configuration.smtpPort
                    };

                    MailMessage messageObj = new MailMessage();

                    //code to build and send email to recipient
                    messageObj.To.Add(mailRecipient);
                    messageObj.Bcc.Add(new MailAddress("jsietsma@nycwatershed.org"));
                    messageObj.From = new MailAddress(Configuration.smtpUserEmail);
                    messageObj.IsBodyHtml = true;
                    messageObj.Subject = "Document Added: " + arg.Name;
                    messageObj.Body = CreateEmailBody(arg, uFinalPath, uDocUploadTime, mailType);

                    try
                    {
                        smtp.Send(messageObj);
                    }
                    catch (SmtpFailedRecipientException ex)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.InnerException);
                        Console.WriteLine();
                        Console.ResetColor();

                        //Return false if message failed to send
                        sendSuccess = false;
                    }
                    catch (SmtpException ex)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.InnerException);
                        Console.WriteLine();
                        Console.ResetColor();

                        //Return false if message failed to send
                        sendSuccess = false;
                    }
                }

                return sendSuccess;    
            }

            //Build the email body with placeholders for data, defined by type of mailing 'single', 'summary', or 'duplicate'
            /// <summary>
            /// Build body of email to send on file upload with placeholders
            /// </summary>
            /// <param name="args">FileSystemWatcher arguments from the file drop</param>
            /// <param name="uFinalPath">Final path to uploaded file</param>
            /// <param name="uDocUploadTime">Time document was uploaded</param>
            /// <param name="mailType">type of email to send (single or multiple files uploaded)</param>
            /// <returns>HTML body of the email to send</returns>
            public static string CreateEmailBody(FileSystemEventArgs args, string uFinalPath, DateTime uDocUploadTime, string mailType = "single")
            {
                string emailTemplate = mailType;
                string farmID = args.Name.Split('_')[1];

                uFinalPath = uFinalPath.Replace(@"E:\Projects\fame uploads\Farms\" + farmID + "\\", "");

                string body = string.Empty;

                switch (mailType)
                {
                    case "single":
                        {

                            using (StreamReader reader = new StreamReader("../../EmailSingleTemplate.html"))
                            {
                                body = reader.ReadToEnd();

                                body = body.Replace("~FarmID~", farmID);
                                body = body.Replace("~FileName~", args.Name);
                                body = body.Replace("~DestinationURL~", uFinalPath);
                                body = body.Replace("~uDocUploadTime~", uDocUploadTime.ToString());

                            }

                            break;

                        }

                    case "summary":
                        {

                            using (StreamReader reader = new StreamReader("../../EmailSummaryTemplate.html"))
                            {

                                body = reader.ReadToEnd();

                            }

                            break;

                        }

                    case "duplicate":
                        {

                            using (StreamReader reader = new StreamReader("../../EmailDuplicateTemplate.html"))
                            {
                                body = reader.ReadToEnd();

                                body = body.Replace("~FileName~", args.Name);
                                body = body.Replace("~DestinationURL~", uFinalPath);
                                body = body.Replace("~uDocUploadTime~", uDocUploadTime.ToString());

                            }

                            break;

                        }
                }

                return body;

            }

        #endregion

        #region Upload Methods and actions...

            //Main method for handling file drops
            /// <summary>
            /// Main method for the service, controls all actions that occur when new file is dropped for upload.
            /// </summary>
            /// <param name="source">object source of the file.created action</param>
            /// <param name="e">FileSystemEventArgs object of the file.created action</param>
            public static void OnFileDropped(object source, FileSystemEventArgs e)
            {
                FameBaseDocument baseDoc = new FameBaseDocument(e);                        

                switch (baseDoc.DocumentType)
                {

                    #region WAC Participant Document Types...
                    case "ASBUILT":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\As-Builts and Procurement", "", baseDoc.DocumentType);
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "ASR":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\ASRs", "A_ASR", baseDoc.DocumentType);
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "NMCP":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\Nutrient Mgmt\Nm Credits", "A_NMP", baseDoc.DocumentType);
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "NMP":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\Nutrient Mgmt\NM Plans", "A_NMP", baseDoc.DocumentType);
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "WFP0":
                    case "WFP-0":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,1,2 COS\WFP-0", "A_OVERFORM", @"WFP-0");
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "WFP1":
                    case "WFP-1":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,1,2 COS\WFP-1", "A_OVERFORM", @"WFP-1");
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "WFP2":
                    case "WFP-2":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,1,2 COS\WFP-2", "A_WFP2", @"WFP-2");
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "AEM":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, "AEM", "A_AEM", baseDoc.DocumentType);
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "TIER1":
                    case "TIER-1":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"AEM\Tier1", "A_TIER1", @"TIER-1");
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "TIER2":
                    case "TIER-2":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"AEM\Tier2", "A_TIER2", @"TIER-2");
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "ALTR":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, "Correspondence", "A_ALTR", baseDoc.DocumentType);
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "COS":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,1,2, COS\COS", "A_OVERFORM", baseDoc.DocumentType);
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "CRP1":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Procurement\CREP", "A_OVERFORM", baseDoc.DocumentType);
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }

                    case "OM":
                        {
                            FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\O&Ms", "A_FORMWAC", baseDoc.DocumentType);
                                NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                                NewParticipantDocument.AssignPK(2, null);
                                NewParticipantDocument.AssignPK(3, null);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                            break;
                        }
                
                    #endregion

                    #region WAC Contractor Document Types...

                    case "GeneralLiability":
                    case "LIABILITY":
                    case "CERTLIAB":
                        {
                            IFameDocument NewLiabilityDocument = baseDoc;
                            bool validEntity = false;

                            if (NewLiabilityDocument.DetermineDocEntityType(out validEntity) == "participant" && validEntity)
                            {
                                NewLiabilityDocument = NewLiabilityDocument.ConvertToParticipantDocument(e, "W-9", "A_PART_W9", baseDoc.DocumentType);
                            }
                            else if (NewLiabilityDocument.DetermineDocEntityType(out validEntity) == "contractor" && validEntity)
                            {
                                NewLiabilityDocument = NewLiabilityDocument.ConvertToContractorDocument(e, "W-9", "A_CONT_W9", baseDoc.DocumentType);
                            }
                            else
                            {
                                throw new InvalidDocumentEntityException(e);
                            }

                            //Attempt to process the upload request and move the file
                            ProcessUploadAttempt(e, NewLiabilityDocument.FinalFilePath);

                            //Add document information to FAME database
                            AddFameDoc(NewLiabilityDocument.FinalFilePath, NewLiabilityDocument.DocumentName, NewLiabilityDocument.DocumentTypeFolderSectorCode,
                                       NewLiabilityDocument.PK1, NewLiabilityDocument.PK2, NewLiabilityDocument.PK3, NewLiabilityDocument.WacUploadUser, out string errorMessage);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewLiabilityDocument.FinalFilePath);

                            break;
                        }

                    case "WORKCOMP":
                        {
                            FameContractorDocument NewContractorDocument = baseDoc.ConvertToContractorDocument(e, "Workers Comp", "CONT_COMP", baseDoc.DocumentType);

                            //Attempt to process the upload request and move the file
                            ProcessUploadAttempt(e, NewContractorDocument.FinalFilePath);

                            //Add document information to FAME database
                            AddFameDoc(NewContractorDocument.FinalFilePath, NewContractorDocument.DocumentName, NewContractorDocument.DocumentTypeFolderSectorCode,
                                NewContractorDocument.PK1, NewContractorDocument.PK2, NewContractorDocument.PK3, NewContractorDocument.WacUploadUser, out string errorMessage);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewContractorDocument.FinalFilePath);

                            break;
                        }

                    case "IRSW9F":
                    case "IRSW9":
                        {
                            IFameDocument NewIRSW9Document = baseDoc;
                            bool validEntity = false;

                            if (NewIRSW9Document.DetermineDocEntityType(out validEntity) == "participant" && validEntity)
                            {
                                NewIRSW9Document = NewIRSW9Document.ConvertToParticipantDocument(e, "W-9", "A_PART_W9", baseDoc.DocumentType);
                            }
                            else if(NewIRSW9Document.DetermineDocEntityType(out validEntity) == "contractor" && validEntity)
                            {
                                NewIRSW9Document = NewIRSW9Document.ConvertToContractorDocument(e, "W-9", "A_CONT_W9", baseDoc.DocumentType);
                            }
                            else
                            {                                
                                throw new InvalidDocumentEntityException(e);                                
                            }

                            //Attempt to process the upload request and move the file
                            ProcessUploadAttempt(e, NewIRSW9Document.FinalFilePath);

                            //Add document information to FAME database
                            AddFameDoc(NewIRSW9Document.FinalFilePath, NewIRSW9Document.DocumentName, NewIRSW9Document.DocumentTypeFolderSectorCode,
                                NewIRSW9Document.PK1, NewIRSW9Document.PK2, NewIRSW9Document.PK3, NewIRSW9Document.WacUploadUser, out string errorMessage);

                            ShowVerboseOutput(true, e.Name, e.ChangeType.ToString(), NewIRSW9Document.FinalFilePath);

                            break;
                        }
                    #endregion

                    default:
                        {
                            Console.WriteLine($@"Unknown Document Type: '{ baseDoc.DocumentType }' has been detected.  Document WILL NOT be uploaded.");
                            Console.WriteLine();

                            throw new InvalidDocumentTypeException(baseDoc.DocumentType);
                        }

                }
                            
            }

            //Move the file to the appropriate destination based on doc type and participant type
            /// <summary>
            /// Move the file from the upload folder to the document final destination
            /// </summary>
            /// <param name="fileSource">path to the source file</param>
            /// <param name="fileDestination">path to the destination file</param>
            /// <param name="error">Holds the errors in the event of a failed move</param>
            /// <returns>success or failure based on move attempt</returns>
            public static bool UploadFile(string fileSource, string fileDestination, out string error)
                {
                    bool finalStatus = false;

                    try
                    {
                        File.Move(Configuration.cfgWatchDir + @"\" + fileSource, fileDestination);

                        finalStatus = true;

                        error = null;
                    }
                    catch (Exception e)
                    {
                        error = e.Message;

                        finalStatus = false;
                    }      

                    return finalStatus;
                }

            //Process the attempted file upload and act accordingly
            /// <summary>
            /// Attempt the upload process, if enabled send verification email, log successes or errors
            /// </summary>
            /// <param name="e"></param>
            /// <param name="finalFilePath"></param>
            public static void ProcessUploadAttempt(FileSystemEventArgs e, string finalFilePath)
            {
                //Attempt to upload the file to the final destination
                if (FameLibrary.UploadFile(e.Name, finalFilePath, out string uploadError))
                {
                    //Send email notification of successful upload
                    SendUploadedFileEmail(e, finalFilePath, DateTime.Now);

                    //Write success messages to FAME log and Windows Event log
                    WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                    LogWindowsEvent(DateTime.Now.ToString() + " - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                    Console.WriteLine(e.Name + " has been successfully uploaded to " + finalFilePath);
                }
                else
                {
                    //Send email notification of successful upload
                    SendUploadedFileEmail(e, finalFilePath, DateTime.Now, false, uploadError);

                    //Write failure messages to FAME log and Windows Event log
                    WriteFameLog(e, "notice", " ", e.Name + " could not be uploaded to " + finalFilePath);
                    LogWindowsEvent(DateTime.Now.ToString() + " - " + e.Name + " could not be " + e.ChangeType + " to FAME.  No changes have been made. ");

                    Console.WriteLine("File could not be uploaded, Please try again: ");
                    Console.WriteLine($@"{ uploadError }");
                }

            }                  
                
            //Build sql, execute query string for inserting document records
            /// <summary>
            /// Build and execute SQL query for inserting document details into FAME database
            /// </summary>
            /// <param name="finalFilePath">Final destintion path for document</param>
            /// <param name="docFileName">File name of document</param>
            /// <param name="wacDocTypeSectorFolderCode">Sector folder code to merge with existing database structure</param>
            /// <param name="pk1"></param>
            /// <param name="pk2"></param>
            /// <param name="pk3"></param>
            /// <param name="wacDocUploader">User who uploaded document, defaults to FameDocUploader</param>
            /// <param name="errorMessage"></param>
            /// <param name="entityType"></param>
            /// <returns>True if insert was successful, false if not</returns>
            public static bool AddFameDoc(string finalFilePath, string docFileName, string wacDocTypeSectorFolderCode, int pk1, int? pk2, int? pk3, string wacDocUploader, out string errorMessage, string entityType = "participant")
            {
                bool finalStatus;
                int queryResult;

                string uploadTimestamp = DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss.fff");

                string queryString = $@"
                    INSERT INTO { Configuration.cfgSQLDatabase }.dbo.{ Configuration.cfgSQLTable } 
                        ([filename_actual], [filename_display], [fk_participantTypeSectorFolder_code], [created_by], [created], [modified_by], [modified], [PK_1], [PK_2], [PK_3])
                    VALUES
                        ('{ finalFilePath }', '{ docFileName }', '{ wacDocTypeSectorFolderCode }', '{ wacDocUploader }', '{ uploadTimestamp }', '{ wacDocUploader }', '{ uploadTimestamp }', '{ pk1 }', '{ pk2 }', '{ pk3 }')
                    ";

                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    try
                    {
                        conn.Open();                  
                        SqlCommand query = new SqlCommand(queryString, conn);
                        queryResult = query.ExecuteNonQuery();
                        conn.Close();

                        errorMessage = null;
                        finalStatus = true;
                    }
                    catch (Exception e)
                    {
                        WriteFameLog("error", e.Message);
                        LogWindowsEvent(e.Message, EventLogEntryType.Error);

                        errorMessage = e.Message;
                        finalStatus = false;
                    }
                }

                return finalStatus;
            }

            
            
        #endregion

        #region Internal Program Configuration Methods...

            //Runs when the mailtimer ticks.  Used for summary emails if sending emails are enabled
            /// <summary>
            /// If sending status emails are enabled, fires this method on decided interval
            /// </summary>
            /// <param name="source">Source object</param>
            /// <param name="e">ElapsedEventArgs object</param>
            public static void MailTimer_Tick(object source, ElapsedEventArgs e)
                {
                    if (ConfigurationManager.AppSettings["EnableUploadEmails"] == "true")
                    {
                        //Do something if we have allowed sending emails through the configuration file
                    }
                }

            //Timer thread to keep service running
            /// <summary>
            /// Timer thread to keep service running
            /// </summary>
            public static void ExecuteWorkerThread()
            {
                while (true)
                {
                    Thread.Sleep(Configuration.cfgWorkerInterval);
                    Console.WriteLine("Worker Thread Status: Working");
                    Console.WriteLine();
                }
            }

            //Get connection string by name from app.config 
            /// <summary>
            /// Retrieve connection string from app.config
            /// </summary>
            /// <param name="connectionName">Connection string name</param>
            /// <returns>string representing the connection string</returns>
            public static string GetConnectionString(string connectionName = Configuration.cfgConStrName)
            {
                return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            }

            //Toggles the FileSystemWatcher monitoring
            /// <summary>
            /// Toggle the FileSystemWatcher monitoring of the configured watch directory
            /// </summary>
            /// <param name="status">True or false depending on if monitoring is running</param>
            /// <param name="fameWatcher">FileSystemWatcher object to associate with</param>
            public static void ToggleMonitoring(bool status, FileSystemWatcher fameWatcher)
            {

                if (status)
                {
                    fameWatcher.EnableRaisingEvents = status;
                    LogWindowsEvent("FAME upload monitoring service has successfully started", EventLogEntryType.Information);
                    WriteFameLog(" - FAME upload monitoring service has successfully started.  Files will now be uploaded to the FAME database.");
                }
                else
                {
                    fameWatcher.EnableRaisingEvents = status;
                    LogWindowsEvent("FAME upload monitoring service has been stopped", EventLogEntryType.Warning);
                    WriteFameLog(" - FAME upload monitoring service has been stopped.  No files will be uploaded until it has been restarted.");
                }

            }

            //Get username of user who dropped file for upload
            /// <summary>
            /// Get the username of the user who dropped file for upload
            /// </summary>
            /// <param name="fileName">name of file dropped</param>
            /// <param name="e">FileSystemEventArgs object which represents drop</param>
            /// <returns>Windows login of user who dropped file</returns>
            public static string GetUploadUserFromEventLog(string fileName, FileSystemEventArgs e)
            {

                string finalUser = string.Empty;

                try
                {
                    //Try to Compare security logs to file drop name and time and pull file uploader from Windows Security event logs.  This requires administrator priviliges for the service or it can not read event log.
                    if (EventLog.SourceExists("Security"))
                    {
                        EventLog log = new EventLog() { Source = "Microsoft Windows security auditing.", Log = "Security" };

                        foreach (EventLogEntry entry in log.Entries)
                        {
                            if ((entry.Message.Contains(Configuration.wacFarmHome) || entry.Message.Contains(Configuration.wacContractorHome)) && (entry.Message.Contains("0x80")) && (!entry.Message.Contains("desktop.ini")))
                            {
                                finalUser = FameLibrary.GetUploadUserName(entry.Message, e.Name);
                            }
                        }
                    }
                    else
                    {
                        WriteFameLog("Specified event source: 'security' does not exist");
                        LogWindowsEvent("Specified event source: 'security' does not exist.", EventLogEntryType.Error);                        
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
                return finalUser;

            }

        #endregion

        #region Extension Methods

        #region FameBaseDocument class extension methods

        //Convert  FameBaseDocument to FameContractorDocument
        /// <summary>
        /// Convert the uploaded base document to a Contractor document
        /// </summary>
        /// <param name="baseDoc">Base document to convert</param>
        /// <param name="e">FileSystemEventArgs object responsible for the drop</param>
        /// <returns>FameContractorDocument object pre-populated</returns>
        public static FameContractorDocument ConvertToContractorDocument(this FameBaseDocument baseDoc, FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector)
                {
                    FameContractorDocument NewContractorDocument = new FameContractorDocument(e, fileSubPath, folderSector, docSector);

                    NewContractorDocument.AssignPK(1, GetParticipantIDFromContractor(NewContractorDocument.ContractorName));
                    NewContractorDocument.AssignPK(2, null);
                    NewContractorDocument.AssignPK(3, null);

                    return NewContractorDocument;
                }

                //Convert FameBaseDocument to FameParticipantDocument
                /// <summary>
                /// Convert the uploaded base document to a Participant document
                /// </summary>
                /// <param name="baseDoc">FameBaseDocument to convert</param>
                /// <param name="e">FileSystemEventArgs object responsible for the drop</param>
                /// <returns>FameParticipantDocument pre-filled with relevent information</returns>
                public static FameParticipantDocument ConvertToParticipantDocument(this FameBaseDocument baseDoc, FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector)
                {
                    FameParticipantDocument NewParticipantDocument = new FameParticipantDocument(e, fileSubPath, folderSector, docSector);
                    
                    NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(NewParticipantDocument.FarmID));
                    NewParticipantDocument.AssignPK(2, null);
                    NewParticipantDocument.AssignPK(3, null);

                    return NewParticipantDocument;
                }

            #endregion

            #region IFameDocument class extension methods

                //Determines if document is participant or contractor document
                /// <summary>
                /// Determine if document is a participant or contractor document based on DocumentEntity
                /// </summary>
                /// <param name="doc">Document to check type on</param>
                /// <param name="validType">true if validEntityType else false</param>
                /// <returns>string either 'participant' or 'contractor'</returns>
                public static string DetermineDocEntityType(this IFameDocument doc, out bool validType)
                {

                    if (GetFarmBusinessByFarmId(doc.DocumentEntity) == 0)
                    {
                        if (GetParticipantIDFromContractor(doc.DocumentEntity) > 0)
                        {
                            validType = true;
                            return "contractor";
                        }

                        validType = false;
                        return null;
                    }
                    else
                    {
                        validType = true;
                        return "participant";
                    }
                }                

                //Insert document information into the FAME database
                /// <summary>
                /// Insert document info into the FAME database
                /// </summary>
                /// <param name="NewDocument">Document to add to FAME</param>
                /// <param name="errorMessage">populates any error message received when upload fails</param>
                /// <returns></returns>
                public static bool AddFameDoc(IFameDocument NewDocument, out string errorMessage)
                {
                    bool finalStatus;
                    int queryResult;

                    string uploadTimestamp = DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss.fff");

                    string queryString = $@"
                            INSERT INTO { Configuration.cfgSQLDatabase }.dbo.{ Configuration.cfgSQLTable } 
                                ([filename_actual], [filename_display], [fk_participantTypeSectorFolder_code], [created_by], [created], [modified_by], [modified], [PK_1], [PK_2], [PK_3])
                            VALUES
                                ('{ NewDocument.FinalFilePath }', '{ NewDocument.DocumentName }', '{ NewDocument.DocumentTypeFolderSectorCode }', '{ NewDocument.WacUploadUser }', '{ uploadTimestamp }', '{ NewDocument.WacUploadUser }', '{ uploadTimestamp }', '{ NewDocument.PK1 }', '{ NewDocument.PK2 }', '{ NewDocument.PK3 }')
                            ";

                    using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand query = new SqlCommand(queryString, conn);
                            queryResult = query.ExecuteNonQuery();
                            conn.Close();

                            errorMessage = null;
                            finalStatus = true;
                        }
                        catch (Exception e)
                        {
                            WriteFameLog("error", e.Message);

                            errorMessage = e.Message;
                            finalStatus = false;
                        }
                    }

                    return finalStatus;
                }

            #endregion

        #endregion
    }
}
