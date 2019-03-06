using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace FameDocumentUploaderSvc
{
    //Class that helps grab configuration settings from app.config and sets program configurations
    /// <summary>
    /// Class which helps grab values from the app.config file and other configuration areas for the service
    /// </summary>
    public static class ConfigurationHelperLibrary
    {

        #region ### App.Config - Data Retrieval ###

        //Get connection string by name from app.config 
        /// <summary>
        /// Retrieve connection string from app.config
        /// </summary>
        /// <param name="connectionName">Connection string name</param>
        /// <returns>string representing the connection string</returns>
        public static string GetConnectionString(string connectionName = ConfigurationHelperLibrary.cfgConStrName)
            {
                return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            }

            //Get Path for farm documents root from app.config
            /// <summary>
            /// Get the path to the farm documents storage folder from app.config
            /// </summary>
            /// <returns>string representing the path to the folder</returns>
            public static string GetFarmDocumentsHome()
            {
                return ConfigurationManager.AppSettings["FarmsHomeFolder"].ToString();
            }

            //Get path for contractor documents root from app.config
            /// <summary>
            /// Get the path to the contractor documents storage folder from app.config
            /// </summary>
            /// <returns>String representing path to the folder</returns>
            public static string GetContractorDocumentsHome()
            {
                return ConfigurationManager.AppSettings["ContractorsHomeFolder"].ToString();
            }

            //Get path for document upload directory from app.config
            /// <summary>
            /// Get the path to the directory we monitor for file uploads from app.config
            /// </summary>
            /// <returns>string representing path to folder that SystemFileWatcher is monitoring</returns>
            public static string GetUploadDirectory()
            {
                return ConfigurationManager.AppSettings["UploadDropDirectory"].ToString();
            }

            //Check if sending emails is permitted from app.config
            /// <summary>
            /// Check whether sending emails is allowed when documents are uploaded from app.config 
            /// </summary>
            /// <returns>True if sending is enabled, false if not</returns>
            public static bool IsSendingEmailsAllowed()
            {
                string stringBool = ConfigurationManager.AppSettings["EnableUploadEmails"].ToString();
                Boolean.TryParse(stringBool, out bool allowSending);

                return allowSending;
            }

            //Get historical logs folder path from app.config
            /// <summary>
            /// Return path to folder where archived logs are kept
            /// </summary>
            /// <returns></returns>
            public static string GetLogArchivePath()
            {
                return ConfigurationManager.AppSettings["ArchiveLogPath"].ToString();
            }
            
            //Get Error logs folder path from app.config
            /// <summary>
            /// Return path to folder where error logs are kept
            /// </summary>
            /// <returns>string representing path to folder</returns>
            public static string GetErrorLogPath()
            {
                return ConfigurationManager.AppSettings["ErrorLogPath"].ToString();
            }

            //Get Transfer logs folder path from app.config
            /// <summary>
            /// Return path to folder where file upload/transfer logs are kept
            /// </summary>
            /// <returns>string representing path to folder</returns>
            public static string GetTransferLogPath()
            {
                return ConfigurationManager.AppSettings["TransferLogPath"].ToString();
            }

            //Get File Upload System logs folder path from app.config
            /// <summary>
            /// Return path to folder where upload system logs are kept
            /// </summary>
            /// <returns>string representing path to folder</returns>
            public static string GetSystemLogPath()
            {
                return ConfigurationManager.AppSettings["SystemLogPath"].ToString();
            }

            //Get email address document uploader uses to send from app.config
            /// <summary>
            /// Return email address for document uploader to use to send upload emails and summaries 
            /// </summary>
            /// <returns>string representing email address uploader uses</returns>
            public static string GetUploaderEmail()
            {
                return ConfigurationManager.AppSettings["UploaderEmailUser"].ToString();
            }

            //Get email password for uploader from app.config
            /// <summary>
            /// Return email password for document uploader's address
            /// </summary>
            /// <returns>string repsenting password for email account</returns>
            public static string GetUploaderEmailPass()
            {
                return ConfigurationManager.AppSettings["UploaderEmailPass"].ToString();
            }

            //Get email port number for uploader from app.config
            /// <summary>
            /// Return email port number to use when uploader sends emails
            /// </summary>
            /// <returns>int representing the port number to use</returns>
            public static int GetUploaderEmailPort()
        {
            bool convertInt = int.TryParse(ConfigurationManager.AppSettings["UploaderEmailPort"].ToString(), out int finalInt);

            return finalInt;
        }

        #endregion

        #region ### Internal Program Configuration Methods ###

        //Runs when the mailtimer ticks.  Used for summary emails if sending emails are enabled
        /// <summary>
        /// If sending status emails are enabled, fires this method on decided interval
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="e">ElapsedEventArgs object</param>
        public static void MailTimer_Tick(object source, ElapsedEventArgs e)
            {
                if (ConfigurationHelperLibrary.IsSendingEmailsAllowed())
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
                    Thread.Sleep(ConfigurationHelperLibrary.cfgWorkerInterval);
                    Console.WriteLine("Worker Thread Status: Working");
                    Console.WriteLine();
                }
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
                    FameLibrary.LogWindowsEvent("FAME upload monitoring service has successfully started", EventLogEntryType.Information);
                    FameLibrary.WriteFameLog(" - FAME upload monitoring service has successfully started.  Files will now be uploaded to the FAME database.");
                }
                else
                {
                    fameWatcher.EnableRaisingEvents = status;
                    FameLibrary.LogWindowsEvent("FAME upload monitoring service has been stopped", EventLogEntryType.Warning);
                    FameLibrary.WriteFameLog(" - FAME upload monitoring service has been stopped.  No files will be uploaded until it has been restarted.");
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
                        if ((entry.Message.Contains(ConfigurationHelperLibrary.wacFarmHome) || entry.Message.Contains(ConfigurationHelperLibrary.wacContractorHome)) && (entry.Message.Contains("0x80")) && (!entry.Message.Contains("desktop.ini")))
                        {
                            finalUser = FameLibrary.GetUploadUserName(entry.Message, e.Name);
                        }
                    }
                }
                else
                {
                    FameLibrary.WriteFameLog("Specified event source: 'security' does not exist");
                    FameLibrary.LogWindowsEvent("Specified event source: 'security' does not exist.", EventLogEntryType.Error);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return finalUser;

        }

        #endregion

        #region ### Email Configuration Section ###

            //Determines if an email is sent when a new file is uploaded to FAME
            public const bool enableSendingUploadEmail = false;

            public const string smtpHost = @"walton.nycwatershed.org";
            public const string smtpUserEmail = @"<FAME Document Uploader> famedocs@nycwatershed.org";
            public const string smtpUser = "famedocs";
            public const string smtpPass = @"Potok4";
            public const int smtpPort = 587;
            public const int cfgMailTimer = 1800000;

        #endregion

        #region ### SQL Configuration Section ###

            public const string cfgConStrName = "wacFameDB";

            public const string cfgSQLServer = @"JamesSietsma-HP\SQLEXPRESS";
            public const string cfgSQLDatabase = @"wacTest";
            public const string cfgSQLUsername = @"famedocs";
            public const string cfgSQLPassword = @"Potok4";
            public const string cfgSQLTable = "documentArchive";

            public static string connectionString = $"Server='{cfgSQLServer}';"
                                                    + $"Database='{cfgSQLDatabase}';"
                                                    + $"User Id='{cfgSQLUsername}';"
                                                    + $"Password='{cfgSQLPassword}';";

        #endregion

        #region ### Program Configuration Section ###

            public const string wacFarmHome = @"E:\Projects\fame uploads\Farms\";
            public const string wacContractorHome = @"E:\Projects\fame uploads\Contractors\";
            public const string cfgWatchDir = @"E:\Projects\fame uploads\upload_drop";

            public const int cfgWorkerInterval = 2000;

        #endregion

        #region ### LDAP Configuration Settings ###

            public const string cfgLDAPServer = @"walton01.wac.local:389";
            public const string cfgLDAPSam = @"WAC\famedocs";
            public const string cfgLDAPUser = @"famedocs";
            public const string cfgLDAPPass = @"Potok4";

        #endregion

    }
}
