using System;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using FameDocumentUploaderSvc;
using System.Timers;

namespace TestConsole
{
    
    public class Program
    {
        public static FileSystemWatcher fameWatcher = new FileSystemWatcher(ConfigurationHelperLibrary.cfgWatchDir);

        public static void Main(string[] args)
        {
            //Create and start new thread for timer to allow program to wait for incoming files
            Thread timerThread = new Thread(new ThreadStart(ConfigurationHelperLibrary.ExecuteWorkerThread));

            //Timer to control mailflow, default every 30 minutes
            System.Timers.Timer MailTimer = new System.Timers.Timer(ConfigurationHelperLibrary.cfgMailTimer);

            //Register events to listen for: Created only
            fameWatcher.Created += new FileSystemEventHandler(FameLibrary.OnFileDropped);

            //Check log messages at predefined intervals and send emails if necessary.            
            MailTimer.Elapsed += new ElapsedEventHandler(ConfigurationHelperLibrary.MailTimer_Tick);

            //This begins the actual file monitoring
            ConfigurationHelperLibrary.ToggleMonitoring(true, fameWatcher);
            timerThread.Start();

            //MailTimer.Start();

        }
    }
}
