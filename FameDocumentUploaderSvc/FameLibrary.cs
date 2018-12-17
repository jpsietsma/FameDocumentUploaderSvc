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

namespace FameDocumentUploaderSvc
{
    public static class FameLibrary
    {
        public static string wacDocUploader;

        //Called when a File Creation is detected
        /// <summary>
        /// Actions to perform when new document is uploaded
        /// </summary>
        /// <param name="source">the object source of the change</param>
        /// <param name="e">FileSystemEvent args from the drop</param>
        public static void OnChanged(object source, FileSystemEventArgs e)
        {

            string docFilePath = e.FullPath;
            string docFileName = e.Name;
            String[] nameParts = docFileName.Split('_');
            string wacDocType = nameParts[0];
            string wacFarmID = nameParts[1];

            string wacFarmHome = Configuration.wacFarmHome;
            string fileSubPath = string.Empty;
            string finalFilePath = string.Empty;
            string docSectorType = string.Empty;

            bool isContractorDoc = false;
            bool validWACDocType = false;
            bool validWACFarmID;

            DateTime docUploadTime = DateTime.Now;
            double docFileSize = new FileInfo(docFilePath).Length;

            //Checks 'wacFarmHome' to see if Farm ID is valid by searching for folder with corresponding farm ID
            if (Directory.Exists(wacFarmHome + wacFarmID))
            {
                validWACFarmID = true;
            }
            else
            {
                validWACFarmID = false;
                WriteFameLog(e, "error", "invalidFarmID");
            }


            //Check to see if the supplied document type is a valid WAC document that should be stored
            //Check if supplied document is a participant or contractor document
            //Determine final document path using document sector type and if document is contractor or participant
            switch (wacDocType)
            {

                case "ASR":
                    {
                        docSectorType = "A_ASR";
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\ASRs";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(DateTime.Now.ToString() + " - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }
                case "AEM":
                    {
                        docSectorType = "A_AEM";
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\WFP-0,WFP-1,WFP-2";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(" - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }
                case "ALTR":
                case "CERTLIAB":
                    {
                        //goes into contractor folder
                        validWACDocType = true;
                        isContractorDoc = true;
                        docSectorType = "A_CERTLIAB";
                        

                        break;
                    }
                case "COS":
                    {
                        docSectorType = "A_COS";
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\WFP-0,1,2 COS\COS";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(" - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }
                case "CRP1":
                case "FPD":
                case "FPF":
                case "FRP":
                case "IRSW9":
                    {
                        //goes into contractor folder
                        validWACDocType = true;
                        isContractorDoc = true;
                        docSectorType = "A_IRSW9";

                        break;
                    }
                case "OM":
                    {
                        docSectorType = "A_OM";
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\O&Ms";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(" - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }
                case "PAPP":
                case "PPD":
                case "RFP":
                case "TIER1":
                    {
                        docSectorType = "A_TIER1";
                        validWACDocType = true;
                        fileSubPath = @"AEM\Tier1";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(" - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }
                case "TIER2":
                    {
                        docSectorType = "A_TIER2";
                        validWACDocType = true;
                        fileSubPath = @"AEM\Tier2";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(" - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }
                case "WFP0":
                    {
                        docSectorType = "A_WFP0";
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\WFP-0,1,2 COS\WFP-0";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(" - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }
                case "WFP1":
                    {
                        docSectorType = "A_WFP1";
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\WFP-0,1,2 COS\WFP-1";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(" - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }
                case "WFP2":
                    {
                        docSectorType = "A_WFP2";
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\WFP-0,WFP-1,WFP-2";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(" - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }
                case "WFPSUBF":
                    {
                        //goes into contractor folder
                        validWACDocType = true;
                        isContractorDoc = true;
                        docSectorType = "A_WFPSUBF";

                        break;
                    }
                case "WORKCOMP":
                    {
                        //goes into contractor folder
                        validWACDocType = true;
                        isContractorDoc = true;
                        docSectorType = "A_WORKCOMP";

                        break;
                    }
                default:
                    {
                        validWACDocType = false;

                        //Write invalid document errors to FAME error log and Windows Event log
                        LogEvent("Invalid or Unknown Document Type: " + nameParts[0] + ". " + nameParts[1] + " was NOT uploaded", EventLogEntryType.Error);
                        WriteFameLog(e, "error", "invalidDocType");

                        break;
                    }

            }

            //Compare security logs to file drop name and time and pull file uploader records from Windows Security event logs
            if (EventLog.SourceExists("Security"))
            {
                EventLog log = new EventLog() { Source = "Security-Auditing", Log = "Security" };

                foreach (EventLogEntry entry in log.Entries)
                {
                    if (entry.Message.Contains(@"E:\Projects\fame uploads\upload_drop") && entry.Message.Contains("0x80") && !entry.Message.Contains("desktop.ini"))
                    {
                        wacDocUploader = GetUploadUserName(entry.Message, e.Name);

                    }

                }
            }
            else
            {
                WriteFameLog("Specified event source: 'security' does not exist or insufficient permissions to access the event log.");
                LogEvent("Specified event source: 'security' does not exist or insufficient permissions to access the event log.", EventLogEntryType.Error);
            }

            //If user drops a valid document type for an existing farm, then add it to database
            if (validWACFarmID && validWACDocType)
            {
                using (SqlConnection conn = new SqlConnection(Configuration.connectionString))
                {
                    try
                    {
                        conn.Open();
                        int queryResult;
                        string queryString = "INSERT INTO "

                            + Configuration.cfgSQLDatabase + ".dbo." + Configuration.cfgSQLTable

                            + "([fileDirectoryPath], [fileName], [fk_fileType], [fk_fileFarmID], [fk_fileUploader], [fileTimestamp], [fileSize]) "

                            + "VALUES("

                            + $" '{finalFilePath}', '{docFileName}', '{wacDocType}', '{wacFarmID}', '{wacDocUploader}', '{docUploadTime}', '{docFileSize}'"

                            + ");";

                        SqlCommand query = new SqlCommand(queryString, conn);
                        queryResult = query.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        LogEvent(ex.Message, EventLogEntryType.Error);
                        WriteFameLog("error", "An error occurred connecting to the database.  Check the event logs for more details.");
                    }
                }
            }
        }

        //Check to make sure error, system, and transfer logs exist in the defined area.
        /// <summary>
        /// Ensures that document uploader log files exist
        /// </summary>
        /// <param name="logType">type of program log to check</param>
        public static void CheckLogFiles(string logType)
        {
            if (logType == "error")
            {
                if (!File.Exists(Configuration.errorLogPath))
                {
                    using (FileStream fs = File.Create(Configuration.errorLogPath))
                    {
                        LogEvent(DateTime.Now.ToString() + " - Daily Error Log Does not exist, the file has been created", EventLogEntryType.Warning);
                    }
                }
            }

            if (logType == "transfer")
            {
                if (!File.Exists(Configuration.transferLogPath))
                {
                    using (FileStream fs = File.Create(Configuration.transferLogPath))
                    {
                        LogEvent(DateTime.Now.ToString() + " - Daily transfer Log Does not exist, the file has been created.", EventLogEntryType.Warning);
                    }
                }
            }

            if (logType == "system")
            {
                if (!File.Exists(Configuration.sysLogPath))
                {
                    using (FileStream fs = File.Create(Configuration.sysLogPath))
                    {
                        LogEvent(DateTime.Now.ToString() + " - Daily System Log Does not exist, the file has been created.", EventLogEntryType.Warning);
                    }
                }
            }
        }

        //Logs event to the Windows Event Log as event type information
        /// <summary>
        /// Logs event to windows event log as an information type log
        /// </summary>
        /// <param name="message">message to write to the log</param>
        public static void LogEvent(string message)
        {
            string eventSource = "FAME Document Upload Watcher";
            DateTime dt = new DateTime();
            dt = System.DateTime.UtcNow;
            message = dt.ToLocalTime() + ": " + message;

            EventLog.WriteEntry(eventSource, message);
        }


        //Logs event to the windows event log as supplied specific event type
        /// <summary>
        /// Log event to the windows event log as passed entry type
        /// </summary>
        /// <param name="message">Message to write to the event log</param>
        /// <param name="e">specifies the type of log to write</param>
        public static void LogEvent(string message, EventLogEntryType e)
        {
            string eventSource = "FAME Document Upload Watcher";
            DateTime dt = new DateTime();
            dt = System.DateTime.UtcNow;
            message = dt.ToLocalTime() + ": " + message;

            EventLog.WriteEntry(eventSource, message, e);
        }

        //Executes when the timer workerThread is started
        /// <summary>
        /// Begin the worker thread for the service
        /// </summary>
        public static void ExecuteWorkerThread()
        {
            while (true)
            {
                Thread.Sleep(5000);
                Console.WriteLine("Worker Thread Status: Working");
                Console.WriteLine();
            }
        }

        //Write to the FAME uploader program logs, using specific log types
        /// <summary>
        /// Write to the FAME uploader program logs, using specific log types
        /// </summary>
        /// <param name="arg">FileSystemWatcher event to log</param>
        /// <param name="logType">Type of log to write</param>
        /// <param name="errSub"></param>
        /// <param name="addmsg">Message to write to the log</param>
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

                        if (errSub == "invalidFarmID")
                        {
                            using (StreamWriter file = new StreamWriter(Configuration.errorLogPath, true))
                            {
                                message += "Invalid Farm ID - " + (arg.Name).Split('_')[1] + " - upload cancelled.";
                                file.WriteLine(message);
                            }

                        }
                        else if (errSub == "invalidDocType")
                        {
                            using (StreamWriter file = new StreamWriter(Configuration.errorLogPath, true))
                            {
                                message += "Invalid Document Type - " + (arg.Name).Split('_')[0] + " - upload cancelled.";
                                file.WriteLine(message);
                            }
                        }

                        break;
                    }
                case "notice":
                    {
                        CheckLogFiles("transfer");

                        using (StreamWriter file = new StreamWriter(Configuration.transferLogPath, true))
                        {
                            message += addmsg;
                            file.WriteLine(message);
                        }

                        break;
                    }
                case "status":
                    {
                        CheckLogFiles("system");

                        using (StreamWriter file = new StreamWriter(Configuration.sysLogPath, true))
                        {
                            message += addmsg;
                            file.WriteLine(message);
                        }

                        break;
                    }
            }
        }

        //Writes to the FAME uploader system log
        public static void WriteFameLog(string msg)
        {
            string message = DateTime.Now.ToString(@"HH:mm:sstt");
            message += msg;

            CheckLogFiles("system");
            using (StreamWriter file = new StreamWriter(Configuration.sysLogPath, true))
            {
                file.WriteLine(message);
            }

        }

        //Writes to specified FAME log, supplied message
        public static void WriteFameLog(string logType, string msg)
        {
            string message = DateTime.Now.ToString(@"HH:mm:sstt - ");
            string logTypePath = null;

            message += msg;

            CheckLogFiles(logType);

            switch (logType)
            {

                case "error": {

                        logTypePath = Configuration.errorLogPath;

                        break;
                    }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(logTypePath, true))
            {
                file.WriteLine(message);
            }

        }

        //Toggles the FileSystemWatcher monitoring
        /// <summary>
        /// Toggle FileSystemWatcher on or off
        /// </summary>
        /// <param name="status">true or false for monitoring</param>
        /// <param name="fameWatcher">Instance of FileSystemWatcher object</param>
        public static void ToggleMonitoring(bool status, FileSystemWatcher fameWatcher)
        {

            if (status)
            {
                fameWatcher.EnableRaisingEvents = status;
                LogEvent("FAME upload monitoring has successfully started", EventLogEntryType.Information);
                WriteFameLog(" - FAME upload monitoring has successfully started");

            }
            else
            {

                fameWatcher.EnableRaisingEvents = status;
                LogEvent("FAME upload monitoring has been stopped", EventLogEntryType.Warning);
                WriteFameLog(" - FAME upload monitoring has been stopped.  No files will be uploaded until it has been restarted.");

            }

        }

        //When passed an event log entry and a filename, determines the uploader of the file by checking Windows Security event log entries
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
            string mailRecipient = username;
           
            SmtpClient smtp = new SmtpClient(Configuration.smtpHost, Configuration.smtpPort);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Configuration.smtpUser, Configuration.smtpPass);
            smtp.Host = Configuration.smtpHost;
            smtp.EnableSsl = false;
            smtp.Port = Configuration.smtpPort;

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

        //Get connection string by name from app.config 
        /// <summary>
        /// Retrieve connection string from app.config
        /// </summary>
        /// <param name="connectionName">Connection string name</param>
        /// <returns>string representing the connection string</returns>
        public static string GetConnectionString(string connectionName = "wacFameDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        //Get pk_farmBusiness by Farm ID
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
                //If enabled, build and send email notification of successful upload
                if (Configuration.enableSendingUploadEmail)
                {
                    SendUploadedFileEmail(e, finalFilePath, DateTime.Now);
                }

                //Write success messages to FAME log and Windows Event log
                WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                LogEvent(DateTime.Now.ToString() + " - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");
            }
            else
            {
                //If enabled, build and sent failure email
                if (Configuration.enableSendingUploadEmail)
                {
                    SendUploadedFileEmail(e, finalFilePath, DateTime.Now, false, uploadError);
                }

                //Write failure messages to FAME log and Windows Event log
                WriteFameLog(e, "notice", " ", e.Name + " could not be uploaded to " + finalFilePath);
                LogEvent(DateTime.Now.ToString() + " - " + e.Name + " could not be " + e.ChangeType + " to FAME.  No changes have been made. ");

                Console.WriteLine("File could not be uploaded, Please try again: ");
                Console.WriteLine($@"{ uploadError }");
            }

        }

        //Build destination file path for upload
        /// <summary>
        /// Build file destination path for newly uploaded files
        /// </summary>
        /// <param name="contractorName">Name of the contractor which document belongs</param>
        /// <param name="fileSubPath">The type of document which determines sub folder</param>
        /// <param name="docFileName">The file name of the document</param>
        /// <returns>string representing destination file path</returns>
        public static string BuildUploadFilePath(bool isContractor, string wacEntityName, string fileSubPath, string docFileName)
        {
            if (isContractor)
            {
                return $@"{ Configuration.wacContractorHome }\{ wacEntityName }\{ fileSubPath }\{ docFileName }";

            }
            else
            {
                return $@"{ Configuration.wacFarmHome }\{ wacEntityName }\{ fileSubPath }\{ docFileName }";
            }
        }

    }
}
