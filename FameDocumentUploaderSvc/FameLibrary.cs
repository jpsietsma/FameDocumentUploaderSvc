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
using System.Data;
using System.Collections.Generic;
using System.Timers;
using FameDocumentUploaderSvc.Models;
using System.Linq;
using static FameDocumentUploaderSvc.ConfigurationHelperLibrary;

namespace FameDocumentUploaderSvc
{
    public static class FameLibrary
    {
        #region Development Methods...

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

        #region Logging Methods...

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

                            logTypePath = GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log";

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
                                using (StreamWriter file = new StreamWriter(GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log", true))
                                {
                                    message += "Invalid Farm ID or Contractor - " + (arg.Name).Split('_')[1] + " - upload cancelled.";
                                    file.WriteLine(message);
                                                                    
                                }

                                LogWindowsEvent(message, EventLogEntryType.Warning);

                            }
                            else if (errSub == "invalidDocType")
                            {
                                using (StreamWriter file = new StreamWriter(GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log", true))
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

                            using (StreamWriter file = new StreamWriter(GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_transfer.log", true))
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

                            using (StreamWriter file = new StreamWriter(GetSystemLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log", true))
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
                using (StreamWriter file = new StreamWriter(GetSystemLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log", true))
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
                switch (logType)
                {
                    case "error":
                        {
                            if (!File.Exists(GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log"))
                            {
                                using (FileStream fs = File.Create(GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log"))
                                {

                                }

                                WriteFameLog(" - Daily Error Log Does not exist, the file has been created");
                            }

                            break;
                        }

                    case "transfer":
                        {
                            if (!File.Exists(GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_transfer.log"))
                            {
                                using (FileStream fs = File.Create(GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_transfer.log"))
                                {

                                }

                                WriteFameLog(" - Daily transfer Log Does not exist, the file has been created.");
                            }

                            break;
                        }

                    case "system":
                        {
                            if (!File.Exists(GetSystemLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log"))
                            {
                                using (FileStream fs = File.Create(GetSystemLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log"))
                                {
                            
                                }

                                WriteFameLog(" - Daily System Log Does not exist, the file has been created.");
                            }

                            break;
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

            //Get the pk_asrAg for document by ASR year
            /// <summary>
            /// Get the pk for the ASR of the indicated year for the indicated farm ID
            /// </summary>
            /// <param name="asrYear">Year of ASR to query</param>
            /// <param name="farmID">Farm ID of farm to query</param>
            /// <returns>null if no match or pk of record if match found</returns>
            public static int? GetAsrPkByYear(int asrYear, string farmID)
            {
                Int32? finalPK = null;

                using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    try
                    {
                        cnn.Open();
                        SqlCommand sql = new SqlCommand($@"SELECT pk_asrAg FROM dbo.asrAg WHERE fk_farmBusiness = '{ GetFarmBusinessByFarmId(farmID) }' AND year = { asrYear }", cnn);
                        finalPK = (Int32)sql.ExecuteScalar();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                int? pk = finalPK;

                return finalPK;
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

                using (SqlConnection conn = new SqlConnection(connectionString))
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

            //Get WFP-3 Package PK by PackageName
            public static int GetWfp3PackagePkByPackageName(string packageName)
            {
                int finalPk = 0;

                using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    try
                    {
                        cnn.Open();
                        SqlCommand sql = new SqlCommand($@"SELECT pk_form_wfp3 FROM dbo.form_wfp3 WHERE packageName = '{ packageName }'", cnn);
                        Int32 pkWFP3Form = (Int32)sql.ExecuteScalar();
                        finalPk = pkWFP3Form;
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }

                return finalPk;
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
                if (IsSendingEmailsAllowed())
                {                
                    string mailRecipient = username;

                    SmtpClient smtp = new SmtpClient(smtpHost, smtpPort)
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(smtpUser, smtpPass),
                        Host = smtpHost,
                        EnableSsl = false,
                        Port = smtpPort
                    };

                    MailMessage messageObj = new MailMessage();

                    //code to build and send email to recipient
                    messageObj.To.Add(mailRecipient);
                    messageObj.Bcc.Add(new MailAddress("jsietsma@nycwatershed.org"));
                    messageObj.From = new MailAddress(smtpUserEmail);
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
                bool showVerbose = true;

                switch (baseDoc.DocumentType)
                {

                    #region WAC Participant Document Types...
                    case "ASBUILT":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\As-Builts and Procurement", "", baseDoc.DocumentType);
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;

                    }

                    case "AEM":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, "AEM", "A_AEM", baseDoc.DocumentType);
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(NewParticipantDocument.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "ALTR":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,1,2 COS\COS", "A_OVERFORM", baseDoc.DocumentType);
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "ASR":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\ASRs", "A_ASR", baseDoc.DocumentType);
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));

                        int? asrPK2 = null;
                        int asrPK2_Year = DateTime.Now.Year;                      

                        //Check the length of array of file name parts [ASR_DEC-xxx_????.pdf]
                        //If length is 2, ASR is for current year if its 3 then its a record for a prior year
                        if (e.Name.Split('_').Length == 3)
                        {
                            int.TryParse(e.Name.Split('_')[2].Replace(@".pdf", ""), out asrPK2_Year);

                            asrPK2 = GetAsrPkByYear(asrPK2_Year, NewParticipantDocument.DocumentEntity);
                            NewParticipantDocument.AssignPK(2, asrPK2);
                        }
                        else if(e.Name.Split('_').Length == 2)
                        {
                            asrPK2 = GetAsrPkByYear(asrPK2_Year, NewParticipantDocument.DocumentEntity);
                            NewParticipantDocument.AssignPK(2, asrPK2);
                        }
                                
                        NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        //Attempt to update the database with the appropriate information
                        AddFameDoc(NewParticipantDocument, out string error);

                        //ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "COS":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,1,2, COS\COS", "A_OVERFORM", baseDoc.DocumentType);
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "CRP1":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Procurement\CREP", "A_OVERFORM", baseDoc.DocumentType);
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    //For CREP
                    case "FSA":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\As-Builts & Procurement\CREP", "A_OVERFORM", baseDoc.DocumentType);
                        NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                        NewParticipantDocument.AssignPK(2, null);
                        NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "NMCP":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\Nutrient Mgmt\Nm Credits", "A_NMP", baseDoc.DocumentType);
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "NMP":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\Nutrient Mgmt\NM Plans", "A_NMP", baseDoc.DocumentType);
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        //Add the document to FAME
                        AddFameDoc(NewParticipantDocument, out string error);

                        if (!string.IsNullOrEmpty(error) || showVerbose)
                        {
                            Console.WriteLine();
                            Console.WriteLine("-------- Verbose Debug Info ---------");
                            Console.WriteLine(error);
                            Console.WriteLine();
                            ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine();
                        }                        

                        break;
                    }

                    case "OM":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\O&Ms", "A_FORMWAC", baseDoc.DocumentType);

                            string packageName = NewParticipantDocument.DocumentName;
                                packageName = packageName.Replace(@".pdf", "");
                                packageName = packageName.Replace(@"OM_", "");
                                                   
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, GetWfp3PackagePkByPackageName(packageName));
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "TIER1":
                    case "TIER-1":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"AEM\Tier1", "A_TIER1", @"TIER-1");

                        if (baseDoc.DocumentEntity.Contains("PK"))
                        {
                            int.TryParse(baseDoc.DocumentEntity.Replace(@"PK", ""), out int pkNum);
                            NewParticipantDocument.AssignPK(1, pkNum);
                        }
                        else
                        {
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                        }
                        
                        NewParticipantDocument.AssignPK(2, null);
                        NewParticipantDocument.AssignPK(3, null);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "TIER2":
                    case "TIER-2":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"AEM\Tier2", "A_TIER1", @"TIER-2");
                        NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                        NewParticipantDocument.AssignPK(2, null);
                        NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "WFP0":
                    case "WFP-0":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,1,2 COS\WFP-0", "A_OVERFORM", @"WFP-0");
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "WFP1":
                    case "WFP-1":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,1,2 COS\WFP-1", "A_OVERFORM", @"WFP-1");
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewParticipantDocument);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "WFP2":
                    case "WFP-2":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,1,2 COS\WFP-2", "A_WFP2", @"WFP-2");
                            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(baseDoc.DocumentEntity));
                            NewParticipantDocument.AssignPK(2, null);
                            NewParticipantDocument.AssignPK(3, null);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }                                                                                                                  
                                        
                    #endregion

                    case "CORR":
                    {
                        IFameDocument NewCorrespondanceDocument = baseDoc;
                        bool validEntity = false;

                        if (NewCorrespondanceDocument.DetermineDocEntityType(out validEntity) == "participant" && validEntity)
                        {
                            NewCorrespondanceDocument = NewCorrespondanceDocument.ConvertToParticipantDocument(e, @"Correspondance", "A_OVERFORM", baseDoc.DocumentType);
                        }
                        else if (NewCorrespondanceDocument.DetermineDocEntityType(out validEntity) == "contractor" && validEntity)
                        {
                            NewCorrespondanceDocument = NewCorrespondanceDocument.ConvertToContractorDocument(e, @"Correspondance", "A_OVERFORM", baseDoc.DocumentType);
                        }
                        else
                        {
                            throw new InvalidDocumentEntityException(e);
                        }

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewCorrespondanceDocument);

                        break;
                    }

                    #region WAC Contractor Document Types...

                    case "GeneralLiability":
                    case "LIABILITY":
                    case "CERTLIAB":
                    {
                        IFameDocument NewLiabilityDocument = baseDoc;
                        bool validEntity = false;

                        if (NewLiabilityDocument.DetermineDocEntityType(out validEntity) == "participant" && validEntity)
                        {
                            NewLiabilityDocument = NewLiabilityDocument.ConvertToParticipantDocument(e, "W-9", "PART_OVER", baseDoc.DocumentType);
                        }
                        else if (NewLiabilityDocument.DetermineDocEntityType(out validEntity) == "contractor" && validEntity)
                        {
                            NewLiabilityDocument = NewLiabilityDocument.ConvertToContractorDocument(e, "W-9", "PART_OVER", baseDoc.DocumentType);
                        }
                        else
                        {
                            throw new InvalidDocumentEntityException(e);
                        }

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewLiabilityDocument);

                        //Add document information to FAME database
                        AddFameDoc(NewLiabilityDocument, out string errorMessage);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewLiabilityDocument.FinalFilePath);

                        break;
                    }

                    case "WORKCOMP":
                    {
                        FameContractorDocument NewContractorDocument = baseDoc.ConvertToContractorDocument(e, "Workers Comp", "PART_OVER", baseDoc.DocumentType);

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewContractorDocument);

                        //Add document information to FAME database
                        AddFameDoc(NewContractorDocument, out string errorMessage);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewContractorDocument.FinalFilePath);

                        break;
                    }

                    case "IRSW9F":
                    case "IRSW9":
                    {
                        IFameDocument NewIRSW9Document = baseDoc;
                        bool validEntity = false;

                        if (NewIRSW9Document.DetermineDocEntityType(out validEntity) == "participant" && validEntity)
                        {
                            NewIRSW9Document = NewIRSW9Document.ConvertToParticipantDocument(e, "W-9", "PART_OVER", baseDoc.DocumentType);
                        }

                        if (NewIRSW9Document.DetermineDocEntityType(out validEntity) == "contractor" && validEntity)
                        {
                            NewIRSW9Document = NewIRSW9Document.ConvertToContractorDocument(e, "W-9", "PART_OVER", baseDoc.DocumentType);
                        }
                        else
                        {                                
                            throw new InvalidDocumentEntityException(e);                                
                        }

                        //Attempt to process the upload request and move the file
                        ProcessUploadAttempt(e, NewIRSW9Document);

                        //Add document information to FAME database
                        AddFameDoc(NewIRSW9Document, out string errorMessage);

                        ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewIRSW9Document.FinalFilePath);

                        break;
                    }

                    #endregion

                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($@"Unknown Document Type: '{ baseDoc.DocumentType }' has been detected.  Document WILL NOT be uploaded.");
                            Console.ResetColor();
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
            public static bool UploadFile(IFameDocument newDoc, out string error)
                {
                    bool finalStatus = false;

                    try
                    {
                        File.Move(newDoc.DocumentPath, newDoc.FinalFilePath);

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
            public static void ProcessUploadAttempt(FileSystemEventArgs e, IFameDocument newDoc)
            {
                //Attempt to upload the file to the final destination
                if (UploadFile(newDoc, out string uploadError))
                {
                    //Send email notification of successful upload
                    SendUploadedFileEmail(e, newDoc.FinalFilePath, DateTime.Now);

                    //Write success messages to FAME log and Windows Event log
                    WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + newDoc.FinalFilePath);
                    LogWindowsEvent(DateTime.Now.ToString() + " - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                    Console.WriteLine(e.Name + " has been successfully uploaded to " + newDoc.FinalFilePath);
                }
                else
                {
                    //Send email notification of failed upload
                    SendUploadedFileEmail(e, newDoc.FinalFilePath, DateTime.Now, false, uploadError);

                    //Write failure messages to FAME log and Windows Event log
                    WriteFameLog(e, "notice", " ", e.Name + " could not be uploaded to " + newDoc.FinalFilePath);
                    LogWindowsEvent(DateTime.Now.ToString() + " - " + e.Name + " could not be " + e.ChangeType + " to FAME.  No changes have been made. ");

                    Console.WriteLine("File could not be uploaded, Please try again: ");
                    Console.WriteLine($@"{ uploadError }");
                }

            }
        

            //Send email warning of duplicate file upload? -- add suffix to filename? --do nothing and write to error log?
            /// <summary>
            /// Process when a duplicate document is dropped
            /// </summary>
            /// <param name="doc">Duplicate document IFameDocument object</param>
            public static void ProcessDuplicateFile(IFameDocument doc)
            {

                

            }                            
            
        #endregion
                
        #region Extension Methods...

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
                        INSERT INTO { cfgSQLDatabase }.dbo.{ cfgSQLTable } 
                            ( [PK_1], [PK_2], [PK_3], [filename_actual], [fk_participantTypeSectorFolder_code], [created], [created_by], [modified], [modified_by], [filename_display], [filepath])
                        VALUES
                            ('{ NewDocument.PK1 }', '{ NewDocument.PK2 }', '{ NewDocument.PK3 }', '{ NewDocument.DocumentName }', '{ NewDocument.DocumentTypeFolderSectorCode }', '{ uploadTimestamp }', '{ NewDocument.WacUploadUser }', NULL, NULL, '{ NewDocument.DocumentName }', '{ NewDocument.FinalFilePath }')
                        ";

                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand query = new SqlCommand(queryString, conn);
                        queryResult = query.ExecuteNonQuery();

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
