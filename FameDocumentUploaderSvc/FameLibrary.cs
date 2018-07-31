using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Mail;
using System.Net;
using System.DirectoryServices;

namespace FameDocumentUploaderSvc
{
    public static class FameLibrary
    {
        public static string wacDocUploader;

        //Called when a File Creation is detected
        public static void OnChanged(object source, FileSystemEventArgs e)
        {

            string docFilePath = e.FullPath;
            string docFileName = e.Name;
            String[] nameParts = docFileName.Split('_');
            string wacDocType = nameParts[0];
            string wacFarmID = nameParts[1];

            string wacFarmHome = Configuration.wacFarmHome;
            string fileSubPath = null;
            string finalFilePath = null;

            bool validWACDocType;
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
            switch (wacDocType)
            {

                case "ASR":
                    {
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\ASRs";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(DateTime.Now.ToString() + " - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }

                case "NMP":
                    {
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\Nutrient Mgmt";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(DateTime.Now.ToString() + " - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }

                case "WFP0":
                case "WFP1":
                case "WFP2":
                    {
                        validWACDocType = true;
                        fileSubPath = @"Final Documentation\WFP-0,WFP-1,WFP-2";
                        finalFilePath = wacFarmHome + wacFarmID + @"\" + fileSubPath + @"\" + docFileName;

                        //Write success messages to FAME log and Windows Event log
                        WriteFameLog(e, "notice", " ", e.Name + " has been successfully uploaded to " + finalFilePath);
                        LogEvent(" - " + e.Name + " has been " + e.ChangeType + " to FAME.  Database has been updated. ");

                        break;
                    }

                case "AEM":
                case "ALTR":
                case "CERTLIAB":
                case "COS":
                case "CRP1":
                case "FPD":
                case "FPF":
                case "FRP":
                case "IRSW9":
                case "IRSW9F":
                case "OM":
                case "PAPP":
                case "PPD":
                case "RFP":
                case "TIER1":
                case "TIER2":
                case "WFPSUBF":
                default:
                    {
                        validWACDocType = false;

                        //Write invalid document errors to FAME error log and Windows Event log
                        LogEvent("Invalid Document Type: " + nameParts[0] + ". " + nameParts[1] + " was NOT uploaded", EventLogEntryType.Error);
                        WriteFameLog(e, "error", "invalidDocType");

                        break;
                    }

            }

            //Compare security logs to file drop name and time and pull file uploader from Windows Security event logs
            if (EventLog.SourceExists("Security"))
            {
                EventLog log = new EventLog() { Source = "Microsoft Windows security auditing.", Log = "Security" };

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
                WriteFameLog("Specified event source: 'security' does not exist");
                LogEvent("Specified event source: 'security' does not exist.", EventLogEntryType.Error);
            }

            //Check if file has valid farm ID and document type
            //If user drops a valid document type, then add it to database
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
        public static void LogEvent(string message)
        {
            string eventSource = "FAME Document Upload Watcher";
            DateTime dt = new DateTime();
            dt = System.DateTime.UtcNow;
            message = dt.ToLocalTime() + ": " + message;

            EventLog.WriteEntry(eventSource, message);
        }

        //Logs event to the windows event log as supplied specific event type
        public static void LogEvent(string message, EventLogEntryType e)
        {
            string eventSource = "FAME Document Upload Watcher";
            DateTime dt = new DateTime();
            dt = System.DateTime.UtcNow;
            message = dt.ToLocalTime() + ": " + message;

            EventLog.WriteEntry(eventSource, message, e);
        }

        //Executes when the timer workerThread is started
        public static void ExecuteWorkerThread()
        {
            while (true)
            {
                Thread.Sleep(5000);
                Console.WriteLine("Worker Thread Status: Working");
                Console.WriteLine(' ');
            }
        }

        //Write to the FAME uploader program logs, using specific log types
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
        public static string GetUploadUserName(string message, string fileName)
        {
            string finalUserName = message;
            string finalUserDomain = @"WAC\";

            Regex regexPattern = new Regex(@"Account Name:\s*(?<userName>.*)\n");
            Match match = regexPattern.Match(message);

            string finalMessage = finalUserDomain + match.Groups["userName"];

            finalMessage = GetADEmail(finalMessage);

            return finalMessage;
        }

        //Sends a notification email to uploader when a duplicate file upload is attempted
        public static bool SendUploadedFileEmail(FileSystemEventArgs arg, string uFinalPath, DateTime uDocUploadTime, string mailType = "single", string username = @"jsietsma@nycwatershed.org")
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

        //formats WAC\user and finds valid email address from user AD mail property.
        public static string GetADEmail(string uUserName)
        {
            uUserName = uUserName.Split('\\')[1];

            string finalEmail = null;

            // Connect to our LDAP server
            DirectoryEntry dEntry = new DirectoryEntry("LDAP://" + Configuration.cfgLDAPServer, Configuration.cfgLDAPUser, Configuration.cfgLDAPPass);
            DirectorySearcher search = new DirectorySearcher(dEntry);

            // specify the search filter
            search.Filter = "(&(objectClass=user)(SamAccountName=" + uUserName + "))";

            // specify which property values to return in the search

            search.PropertiesToLoad.Add("mail");        // smtp mail address

            // perform the search
            SearchResult result = search.FindOne();

            try
            {
                finalEmail = result.Properties["mail"].ToString();
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("------------------------");
                Console.ResetColor();
            }

            return finalEmail;

        }

    }
}
