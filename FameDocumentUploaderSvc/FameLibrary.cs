using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using FameDocumentUploaderSvc.Models;
using FameDocumentUploaderSvc.UploaderExceptionClasses;
using static FameDocumentUploaderSvc.ConfigurationHelperLibrary;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;

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

                            logTypePath = GetErrorLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log";

                            LogWindowsEvent(message, EventLogEntryType.Error);

                            break;
                    }

                    case "transfer":
                    {

                        logTypePath = GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log";

                        LogWindowsEvent(message, EventLogEntryType.Error);

                        break;
                    }

                    case "system":
                    {

                        logTypePath = GetSystemLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log";

                        LogWindowsEvent(message, EventLogEntryType.Error);

                        break;
                    }
            }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(logTypePath, true))
                {
                    file.WriteLine(message);
                }

            }

            //Writes to specified FAME log, supplied message
            /// <summary>
            /// Write to a specific FAME document uploader log with a specific message
            /// </summary>
            /// <param name="logType">Type of log to write</param>
            /// <param name="msg">Message to write to newly added log</param>
            public static void WriteFameLog(UploaderLogTypes log, string msg)
            {
                string message = DateTime.Now.ToString(@"HH:mm:sstt - ");
                string logTypePath = null;

                message += msg;
                            
                switch (log)
                {

                    case UploaderLogTypes.ERROR:
                        {

                            logTypePath = GetErrorLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log";
                            LogWindowsEvent(message, EventLogEntryType.Error);

                            break;
                        }

                    case UploaderLogTypes.SYSTEM:
                        {

                            logTypePath = GetSystemLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log";
                            LogWindowsEvent(message, EventLogEntryType.Information);

                            break;
                        }

                    case UploaderLogTypes.TRANSFER:
                        {

                            logTypePath = GetTransferLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_transfer.log";
                            LogWindowsEvent(message, EventLogEntryType.Information);

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
                                using (StreamWriter file = new StreamWriter(GetErrorLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log", true))
                                {
                                    message += "Invalid Farm ID or Contractor - " + (arg.Name).Split('_')[1] + " - upload cancelled.";
                                    file.WriteLine(message);
                                                                    
                                }

                                LogWindowsEvent(message, EventLogEntryType.Warning);

                            }
                            else if (errSub == "invalidDocType")
                            {
                                using (StreamWriter file = new StreamWriter(GetErrorLogPath() + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log", true))
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

            //Get a count of how many daily log files exist for a particular log type
            /// <summary>
            /// Gets a count of the number of daily log files that exist for the specified log type
            /// </summary>
            /// <param name="log">Type of log to check</param>
            /// <returns>int representing number of files that exist</returns>
            public static int LogFileCount(UploaderLogTypes log = UploaderLogTypes.ERROR)
            {
                int finalCount = 0;

                switch (log)
                {
                    case UploaderLogTypes.ERROR:
                        {
                            foreach (string file in Directory.GetFiles(GetErrorLogPath()))
                            {
                                finalCount++;
                            }

                            break;
                        }

                    case UploaderLogTypes.TRANSFER:
                        {
                            foreach (string file in Directory.GetFiles(GetTransferLogPath()))
                            {
                                finalCount++;
                            }

                            break;
                        }

                    case UploaderLogTypes.SYSTEM:
                        {
                            foreach (string file in Directory.GetFiles(GetSystemLogPath()))
                            {
                                finalCount++;
                            }

                            break;
                        }
                }

                return finalCount;
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
                            WriteFameLog("error", e.Message);
                            SendFailedFileUploadEmail(farmID, "Filename contains an invalid Farm ID", DateTime.Now);
                            throw new InvalidDocumentEntityException(e, farmID);
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
                        throw new InvalidASRYearException(e, asrYear);
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
                        throw new InvalidDocumentEntityException(e, uFarmBusiness.ToString());
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
                    try
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
                            return numRows;
                        }
                        else
                        {
                            baseQuery = $@"SELECT pk_participant FROM dbo.participant WHERE fullname_FL_dnd = '{ contractorPrefix }'";
                            sqlQuery = new SqlCommand(baseQuery, conn);

                            //get our participant id result from the query and parse it as an INT and set equal with finalParticipantID
                            var participantID = sqlQuery.ExecuteScalar();
                            int.TryParse(participantID.ToString(), out finalParticipantID);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new InvalidDocumentEntityException(e, contractorPrefix);
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
                            WriteFameLog("error", e.Message);
                        LogWindowsEvent(e.Message, EventLogEntryType.Error);
                        }
                    }

                    return finalPk;
                }

        #endregion

        #region Email Configuration Methods...

            //Sends a notification email to uploader when a file is uploaded
            /// <summary>
            /// Send notification email when a file is uploaded
            /// </summary>
            /// <param name="arg">FileSystemWatcher event to email about</param>
            /// <param name="uFinalPath">Final path to the uploaded file</param>
            /// <param name="uDocUploadTime">Time document was uploaded</param>
            /// <param name="mailType">Type of email to send (single vs multiple files)</param>
            /// <param name="username">Email Address to send notification to</param>
            /// <returns>true or false on success or fail of sending email</returns>
            public static bool SendUploadedFileEmail(FileSystemEventArgs arg, string uFinalPath, DateTime uDocUploadTime, bool wasSuccessful, string errorMessage = null, string mailType = "single", string username = @"jsietsma@nycwatershed.org")
            {
                bool sendSuccess = true;

                //If enabled, build and send email
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

                    //code to build and send email to recipient list
                    //messageObj.To.Add(mailRecipient);
                    messageObj.To.Add(new MailAddress("jsietsma@nycwatershed.org"));
                    messageObj.Bcc.Add(new MailAddress("famedocs@nycwatershed.org"));
                    //messageObj.Bcc.Add(new MailAddress("jjackson@nycwatershed.org"));

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
                        WriteFameLog("error", "Unable to send email - <Recipient_error>: " + ex.InnerException);
                        sendSuccess = false;
                    }
                    catch (SmtpException ex)
                    {
                        WriteFameLog("error", "Unable to send email: " + ex.InnerException);
                        sendSuccess = false;
                    }
                }

                return sendSuccess;    
            }
            
            //Sends a notification email to uploader when a failed file upload is attempted
            /// <summary>
            /// Send notification email when duplicate file upload is attempted
            /// </summary>
            /// <param name="arg">FileSystemWatcher event to email about</param>
            /// <param name="uFinalPath">Final path to the uploaded file</param>
            /// <param name="uDocUploadTime">Time document was uploaded</param>
            /// <param name="mailType">Type of email to send (single vs multiple files)</param>
            /// <param name="username">Email Address to send notification to</param>
            /// <returns>true or false on success or fail of sending email</returns>
            public static bool SendFailedFileUploadEmail(FileSystemEventArgs arg, string errorMessage, DateTime uploadTime)
            {
                bool sendSuccess = true;

                //If enabled, build and send failure email
                if (IsSendingEmailsAllowed())
                {           
                    SmtpClient smtp = new SmtpClient(smtpHost, smtpPort)
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(smtpUser, smtpPass),
                        Host = smtpHost,
                        EnableSsl = false,
                        Port = smtpPort
                    };

                    MailMessage messageObj = new MailMessage();

                    //code to build and send email to recipient list
                    //messageObj.To.Add(mailRecipient);
                    messageObj.To.Add(new MailAddress("jsietsma@nycwatershed.org"));
                    messageObj.Bcc.Add(new MailAddress("famedocs@nycwatershed.org"));
                    //messageObj.Bcc.Add(new MailAddress("jjackson@nycwatershed.org"));

                    messageObj.From = new MailAddress(smtpUserEmail);
                    messageObj.IsBodyHtml = true;
                    messageObj.Subject = "Error Uploading: " + arg.Name;
                    messageObj.Body = CreateEmailBody(arg, errorMessage, uploadTime);

                    try
                    {
                        smtp.Send(messageObj);
                    }
                    catch (SmtpFailedRecipientException ex)
                    {
                        WriteFameLog("error", "Unable to send upload failure email - <Recipient_error>: " + ex.InnerException);
                        sendSuccess = false;
                    }
                    catch (SmtpException ex)
                    {
                        WriteFameLog("error", "Unable to send upload failure email: " + ex.InnerException);
                        sendSuccess = false;
                    }
                }

                return sendSuccess;    
            }

            //Sends a notification email to uploader when a failed file upload is attempted with an invalid FarmID
            /// <summary>
            /// Send notification email when duplicate file upload is attempted
            /// </summary>
            /// <param name="farmID">Farm Id that was passed</param>
            /// <param name="uFinalPath">Final path to the uploaded file</param>
            /// <param name="uDocUploadTime">Time document was uploaded</param>
            /// <param name="mailType">Type of email to send (single vs multiple files)</param>
            /// <param name="username">Email Address to send notification to</param>
            /// <returns>true or false on success or fail of sending email</returns>
            public static bool SendFailedFileUploadEmail(string farmID, string errorMessage, DateTime uploadTime)
            {
                bool sendSuccess = true;

                //If enabled, build and send failure email
                if (IsSendingEmailsAllowed())
                {           
                    SmtpClient smtp = new SmtpClient(smtpHost, smtpPort)
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(smtpUser, smtpPass),
                        Host = smtpHost,
                        EnableSsl = false,
                        Port = smtpPort
                    };

                    MailMessage messageObj = new MailMessage();

                    //code to build and send email to recipient list
                    //messageObj.To.Add(mailRecipient);
                    messageObj.To.Add(new MailAddress("jsietsma@nycwatershed.org"));
                    messageObj.Bcc.Add(new MailAddress("famedocs@nycwatershed.org"));
                    //messageObj.Bcc.Add(new MailAddress("jjackson@nycwatershed.org"));

                    messageObj.From = new MailAddress(smtpUserEmail);
                    messageObj.IsBodyHtml = true;
                    messageObj.Subject = "Error Uploading File - Invalid Farm ID: " + farmID;
                    messageObj.Body = CreateEmailBody(farmID, errorMessage, uploadTime);

                    try
                    {
                        smtp.Send(messageObj);
                    }
                    catch (SmtpFailedRecipientException ex)
                    {
                        WriteFameLog("error", "Unable to send upload failure email - <Recipient_error>: " + ex.InnerException);
                        sendSuccess = false;
                    }
                    catch (SmtpException ex)
                    {
                        WriteFameLog("error", "Unable to send upload failure email: " + ex.InnerException);
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

                            using (StreamReader reader = new StreamReader("MailTemplates/EmailSingleTemplate.html"))
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

                            using (StreamReader reader = new StreamReader("MailTemplates/EmailSummaryTemplate.html"))
                            {

                                body = reader.ReadToEnd();

                            }

                            break;

                        }

                    case "duplicate":
                        {

                            using (StreamReader reader = new StreamReader("MailTemplates/EmailDuplicateTemplate.html"))
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

            //Build the email body for a failed upload attempt
            /// <summary>
            /// Build body of email to send on file upload with placeholders
            /// </summary>
            /// <param name="args">FileSystemWatcher arguments from the file drop</param>
            /// <param name="uFinalPath">Final path to uploaded file</param>
            /// <param name="uDocUploadTime">Time document was uploaded</param>
            /// <param name="mailType">type of email to send (single or multiple files uploaded)</param>
            /// <returns>HTML body of the email to send</returns>
            public static string CreateEmailBody(FileSystemEventArgs args, string errorMessage, DateTime uploadTime)
            {
                string farmID = args.Name.Split('_')[1];

                string message = String.Empty;

                string body = message;

                using (StreamReader reader = new StreamReader(@"C:\Users\jsietsma\OneDrive\GitHub\FameDocumentUploaderSvc\FameDocumentUploaderSvc\MailTemplates\EmailErrorTemplate.html"))
                {
                    body = reader.ReadToEnd();

                    body = body.Replace("~FarmID~", farmID);
                    body = body.Replace("~FileName~", args.Name);
                    body = body.Replace("~uDocUploadTime~", uploadTime.ToString());

                }

                return body;
            }

            //Build the email body for a failed upload attempt without filename
            /// <summary>
            /// Build body of email to send on file upload with placeholders
            /// </summary>
            /// <param name="args">FileSystemWatcher arguments from the file drop</param>
            /// <param name="uFinalPath">Final path to uploaded file</param>
            /// <param name="uDocUploadTime">Time document was uploaded</param>
            /// <param name="mailType">type of email to send (single or multiple files uploaded)</param>
            /// <returns>HTML body of the email to send</returns>
            public static string CreateEmailBody(string farmID, string errorMessage, DateTime uploadTime)
            {
                string message = String.Empty;

                string body = message;

                using (StreamReader reader = new StreamReader(@"C:\Users\jsietsma\OneDrive\GitHub\FameDocumentUploaderSvc\FameDocumentUploaderSvc\MailTemplates\EmailErrorTemplate.html"))
                {
                    body = reader.ReadToEnd();

                    body = body.Replace("~FarmID~", farmID);
                    body = body.Replace("~ErrorText~", errorMessage);
                    body = body.Replace("~uDocUploadTime~", uploadTime.ToString());

                }

                return body;
            }

        #endregion

        #region Upload and Archiving Methods...

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

                        //Attempt to check FameDB for existing file
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;

                    }

                    case "AEM":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, "AEM", "A_AEM", baseDoc.DocumentType, false, false);

                        //Attempt to check FameDB for existing file
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "ALTR":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,WFP-1,WFP-2\COS", "A_OVERFORM", baseDoc.DocumentType, false, false);

                        //Attempt to check FameDB for existing file
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "ASR":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\ASRs", "A_ASR", baseDoc.DocumentType, false, true);

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
                            int.TryParse(e.Name.Split('_')[1].Replace(@".pdf", ""), out asrPK2_Year);

                            asrPK2 = GetAsrPkByYear(asrPK2_Year, NewParticipantDocument.DocumentEntity);
                            NewParticipantDocument.AssignPK(2, asrPK2);
                        }                                

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        //ShowVerboseOutput(showVerbose, e.Name, e.ChangeType.ToString(), NewParticipantDocument.FinalFilePath);

                        break;
                    }

                    case "COS":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,WFP-1,WFP-2\COS", "A_OVERFORM", baseDoc.DocumentType, false, false);

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "CRP1":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Procurement\CREP", "A_OVERFORM", baseDoc.DocumentType);

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    //For CREP
                    case "FSA":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\As-Builts & Procurement\CREP", "A_OVERFORM", baseDoc.DocumentType, false, false);

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "NMCP":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\Nutrient Mgmt\Nm Credits", "A_NMP", baseDoc.DocumentType, false, true);

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "NMP":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\Nutrient Mgmt\NM Plans", "A_NMP", baseDoc.DocumentType, true, true);

                        //Add the document to FAME
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);                   

                        break;
                    }

                    case "OM":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\O&Ms", "A_FORMWAC", baseDoc.DocumentType, true, false);

                            string packageName = NewParticipantDocument.DocumentName;
                                packageName = packageName.Replace(@".pdf", "");
                                packageName = packageName.Replace(@"OM_", "");
                                                   
                            NewParticipantDocument.AssignPK(2, GetWfp3PackagePkByPackageName(packageName));

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "TIER1":
                    case "TIER-1":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"AEM\Tier1", "A_TIER1", @"TIER-1", false, false);

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "TIER2":
                    case "TIER-2":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"AEM\Tier2", "A_TIER1", @"TIER-2", false, false);

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "WFP0":
                    case "WFP-0":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,WFP-1,WFP-2\WFP-0", "A_OVERFORM", @"WFP-0", true, false);

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "WFP1":
                    case "WFP-1":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,WFP-1,WFP-2\WFP-1", "A_OVERFORM", @"WFP-1", true, false);

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "WFP2":
                    case "WFP-2":
                    {
                        FameParticipantDocument NewParticipantDocument = baseDoc.ConvertToParticipantDocument(e, @"Final Documentation\WFP-0,WFP-1,WFP-2\WFP-2", "A_WFP2", @"WFP-2", true, false);

                        //Attempt to update the database with the appropriate information
                        NewParticipantDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the file
                        NewParticipantDocument.ProcessUploadAttempt(e);

                        break;
                    }                                                                                                                                                         

                    case "CORR":
                    {
                        IFameDocument NewCorrespondanceDocument = baseDoc;

                        if (NewCorrespondanceDocument.DetermineDocEntityType(out bool validEntity) == "participant" && validEntity)
                        {
                            NewCorrespondanceDocument = NewCorrespondanceDocument.ConvertToParticipantDocument(e, @"Correspondance", "A_OVERFORM", baseDoc.DocumentType, false, false);
                        }
                        else if (NewCorrespondanceDocument.DetermineDocEntityType(out validEntity) == "contractor" && validEntity)
                        {
                            NewCorrespondanceDocument = NewCorrespondanceDocument.ConvertToContractorDocument(e, @"Correspondance", "A_OVERFORM", baseDoc.DocumentType, false, false);
                        }
                        else
                        {
                            throw new InvalidDocumentEntityException(e);
                        }

                        //Attempt to upload document information into FAME database
                        NewCorrespondanceDocument.AddFameDoc(out string error);

                        //Attempt to process the upload request and move the acual file to the document structure
                        NewCorrespondanceDocument.ProcessUploadAttempt(e);

                        break;
                    }
                #endregion

                #region WAC Contractor Doc Types

                case "GeneralLiability":
                    case "LIABILITY":
                    case "CERTLIAB":
                    {
                        IFameDocument NewLiabilityDocument = baseDoc;

                        if (NewLiabilityDocument.DetermineDocEntityType(out bool validEntity) == "participant" && validEntity)
                        {
                            NewLiabilityDocument = NewLiabilityDocument.ConvertToParticipantDocument(e, "General Liability", "PART_OVER", baseDoc.DocumentType, false, true);
                        }
                        else if (NewLiabilityDocument.DetermineDocEntityType(out validEntity) == "contractor" && validEntity)
                        {
                            NewLiabilityDocument = NewLiabilityDocument.ConvertToContractorDocument(e, "General Liability", "PART_OVER", baseDoc.DocumentType, false, true);
                        }
                        else
                        {
                            throw new InvalidDocumentEntityException(e);
                        }

                        //Add document information to FAME database
                        NewLiabilityDocument.AddFameDoc(out string errorMessage);

                        //Attempt to process the upload request and move the file
                        NewLiabilityDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "WORKCOMP":
                    {
                        FameContractorDocument NewContractorDocument = baseDoc.ConvertToContractorDocument(e, "Workers Comp", "PART_OVER", baseDoc.DocumentType, false, true);

                        //Add document information to FAME database
                        NewContractorDocument.AddFameDoc(out string errorMessage);

                        //Attempt to process the upload request and move the file
                        NewContractorDocument.ProcessUploadAttempt(e);

                        break;
                    }

                    case "IRSW9F":
                    case "IRSW9":
                    {
                        IFameDocument NewIRSW9Document = baseDoc;

                        if (NewIRSW9Document.DetermineDocEntityType(out bool validEntity) == "participant" && validEntity)
                        {
                            NewIRSW9Document = NewIRSW9Document.ConvertToParticipantDocument(e, "W-9", "PART_OVER", baseDoc.DocumentType, false, true);
                        }

                        if (NewIRSW9Document.DetermineDocEntityType(out validEntity) == "contractor" && validEntity)
                        {
                            NewIRSW9Document = NewIRSW9Document.ConvertToContractorDocument(e, "W-9", "PART_OVER", baseDoc.DocumentType, false, true);
                        }
                        else
                        {                                
                            throw new InvalidDocumentEntityException(e);                                
                        }

                        //Check FAME database for existing document
                        NewIRSW9Document.AddFameDoc(out string error);

                        //no error message returned, then we proceed to move file to J:\Farms\{FarmID}
                        NewIRSW9Document.ProcessUploadAttempt(e);                       

                        break;
                    }

                #endregion
                                        
                    //User has dropped document with an unrecognized type - throw exception
                    default:
                        {                            
                            try
                            {                                
                                throw new InvalidDocumentTypeException(baseDoc.DocumentType);
                            }
                            catch (InvalidDocumentTypeException ex)
                            {
                                //document the errors in the uploader logs and windows event log and then send email notification of failure
                                ex.LogUploaderException(ex.Message);

                                if (IsSendingEmailsAllowed())
                                {
                                    SendFailedFileUploadEmail(e, ex.Message, DateTime.Now);
                                }
                            }

                            break;                            
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
            public static void ProcessUploadAttempt(this IFameDocument newDoc, FileSystemEventArgs e)
            {
                //Attempt to upload the file to the final destination
                if (UploadFile(newDoc, out string uploadError))
                {
                    //Send email notification of successful upload
                    SendUploadedFileEmail(e, newDoc.FinalFilePath, DateTime.Now, true);

                    //Write success messages to FAME log and Windows Event log
                    WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + newDoc.FinalFilePath);
                    LogWindowsEvent(DateTime.Now.ToString() + " - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                }
                else
                {
                    //Send email notification of failed upload
                    SendFailedFileUploadEmail(e, uploadError, DateTime.Now);

                    //Write failure messages to Windows Event log
                    LogWindowsEvent(DateTime.Now.ToString() + " - " + e.Name + " could not be " + e.ChangeType + " to FAME.  No changes have been made. ");

                }

            }        

            //Archive all logs, i.e. error, system, and transfer by zipping and placing in logs/archived-logs/<Year>_<monthName>.zip
            /// <summary>
            /// Archive the system, error, and transfer log files by zipping them up and moving them to "logs/archived-logs/<YEAR>_<MONTH>.zip"
            /// </summary>
            /// <param name="zipDest">destination to place the zip file when completed</param>
            /// <returns>true if successful or false if failed</returns>
            public static bool ArchiveLogFiles()
            {
                //Build our arrays of log files, one array for each log type
                string[] errorLogs = Directory.GetFiles(GetErrorLogPath());
                string[] transferLogs = Directory.GetFiles(GetTransferLogPath());
                string[] systemLogs = Directory.GetFiles(GetSystemLogPath());

                //Build our master string array of log files, created with the length as the sum of files
                string[] logFiles = new string[errorLogs.Length + transferLogs.Length + systemLogs.Length];

                //Concatenate our 3 lists of log files into the master string array
                errorLogs.CopyTo(logFiles, 0);
                transferLogs.CopyTo(logFiles, errorLogs.Length);
                systemLogs.CopyTo(logFiles, errorLogs.Length + transferLogs.Length);

                try
                {
                    //Move all of our log files into the logs\tmp directory to prepare for zipping and archiving
                    foreach (string logFile in logFiles)
                    {
                        string dest = GetLogArchivePath() + "tmp\\" + logFile.Split('\\')[logFile.Split('\\').Length - 1];
                        File.Move(logFile, dest);
                    } 
                    
                    //Zip the logs/tmp directory and name it with CurrentYear_CurrentMonth, place it in the root of "archived-logs" folder
                    ZipFile.CreateFromDirectory(GetLogArchivePath() + "\\tmp\\", GetLogArchivePath() + DateTime.Now.ToString("yyyy") + "_" + DateTime.Now.ToString("MMMM") + "_LogArchive.zip");      
                
                }
                catch (Exception)
                {
                    //History folder does not exist
                    throw new InvalidDocumentDestinationPathException(GetLogArchivePath());
                }
                
                return true;
            }

        #endregion

        #region Contractor Document Methods

            /// <summary>
            /// Scans document folder and creates folders for all contractors with the appropriate directory structure
            /// </summary>
            public static void UpdateContractorFoldersFromDocuments()
            {
                string NewContractorDocHome = @"J:\CONTRACTORS\Contractor_docs\";
                string OldContractorDocHome = @"Y:\FAMEDOCS\PART\";

                string TmpContractorDocHome = @"J:\CONTRACTORS\Contractor_docs\~GeneratedDocs\";

                List<string> list_contractorFolders = Directory.GetDirectories(NewContractorDocHome).ToList();

                List<string> list_contractorDocs = Directory.GetFiles(OldContractorDocHome).ToList();

                List<string> list_tmpFiles = new List<string>();

                foreach (string _filename in list_contractorDocs)
                {
                    string tmpName = _filename.Split('\\').Last();
                    string[] nameparts = tmpName.Split('_');
                    string DocType = nameparts[0];
                    string DocEntity = nameparts[1].Split('.')[0];

                    if (DocType == "CERTLIAB" || DocType == "IRSW9" || DocType == "WORKCOMP")
                    {
                        if (!Directory.Exists(TmpContractorDocHome + DocEntity))
                        {
                            string sourceStr = NewContractorDocHome + "~NewContractorTemplate";
                            string destStr = TmpContractorDocHome + DocEntity;

                            new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(sourceStr, destStr);
                        }
                    }
                }
            }

        #endregion
    }
}
