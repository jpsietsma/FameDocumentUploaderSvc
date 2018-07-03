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

        public const string smtpHost = @"smtp.gmail.com";
        public const string smtpUserEmail = @"FAME Document Uploader jpsietsma@gmail.com";
        public const string smtpUser = "jpsietsma";
        public const string smtpPass = @"A!12@lop^6";
        public const int smtpPort = 587;

#endregion

#region ########## SQL Configuration Section ##########

        public const string cfgSQLServer = @"POTOKTEST";
        public const string cfgSQLDatabase = "wacTest";
        public const string cfgSQLUsername = "sa";
        public const string cfgSQLPassword = "WacAttack9";
        public const string cfgSQLTable = "testFameUploads";

        public static string connectionString = $"Server='{cfgSQLServer}';"
                                              + $"Database='{cfgSQLDatabase}';"
                                              + $"User Id='{cfgSQLUsername}';"
                                              + $"Password='{cfgSQLPassword}';";

#endregion

#region ########## SystemFileWatcher Configuration Section ##########

        //Directory path to monitor for uploads
        public const string cfgWatchDir = @"E:\projects\fame uploads\upload_drop";

#endregion

#region ########## Log File Configuration Section ##########

        public static string errorLogPath = @"E:\projects\fame uploads\logs\error-logs\" + DateTime.Now.ToString("MM-dd-yyyy") + "_error.log";
        public static string transferLogPath = @"E:\projects\fame uploads\logs\transfer-logs\" + DateTime.Now.ToString("MM-dd-yyyy") + "_transfer.log";
        public static string sysLogPath = @"E:\projects\fame uploads\logs\system-logs\" + DateTime.Now.ToString("MM-dd-yyyy") + "_system.log";

        #endregion

#region ########## Program Configuration Section ##########

        public const string wacFarmHome = @"E:\Projects\fame uploads\Farms\";
        public const string uploadWatch = @"E:\Projects\fame uploads\upload_drop";


#endregion
    }
}
