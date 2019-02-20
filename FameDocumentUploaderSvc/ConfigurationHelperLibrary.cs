using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc
{

    //Class that helps grab information from app.config
    /// <summary>
    /// Class which helps grab values from the app.config file and other configuration areas for the service
    /// </summary>
    public static class ConfigurationHelperLibrary
    {

        #region App.Config - Data Retrieval

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
                bool allowSending = Boolean.TryParse(stringBool, out allowSending);

                return allowSending;
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

    }
}
