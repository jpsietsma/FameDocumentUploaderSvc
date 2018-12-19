using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc
{
    public class Configuration
    {

        #region ########## Email Configuration Section ########## 

        //Determines if an email is sent when a new file is uploaded to FAME
        public const bool enableSendingUploadEmail = false;

        public const string smtpHost = @"walton.nycwatershed.org";
        public const string smtpUserEmail = @"<FAME Document Uploader> famedocs@nycwatershed.org";
        public const string smtpUser = "famedocs";
        public const string smtpPass = @"Potok4";
        public const int smtpPort = 587;
        public const int cfgMailTimer = 1800000;

        #endregion

        #region ########## SQL Configuration Section ##########

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

        #region ########## Log File Configuration Section ##########

        public static string errorLogPath = @"E:\projects\fame uploads\logs\error-logs\" + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log";
        public static string transferLogPath = @"E:\projects\fame uploads\logs\transfer-logs\" + DateTime.Now.ToString("MM-dd-yyyy") + "_transfer.log";
        public static string sysLogPath = @"E:\projects\fame uploads\logs\system-logs\" + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log";

        #endregion

        #region ########## Program Configuration Section ##########

        public const string wacFarmHome = @"E:\Projects\fame uploads\Farms\";
        public const string wacContractorHome = @"E:\Projects\fame uploads\Contractors\";
        public const string cfgWatchDir = @"E:\Projects\fame uploads\upload_drop";

        public const int cfgWorkerInterval = 2000;

        #endregion

        #region ########## LDAP Configuration Settings ##########

        public const string cfgLDAPServer = @"walton01.wac.local:389";
        public const string cfgLDAPSam = @"WAC\famedocs";
        public const string cfgLDAPUser = @"famedocs";
        public const string cfgLDAPPass = @"Potok4";

        #endregion

    }
}