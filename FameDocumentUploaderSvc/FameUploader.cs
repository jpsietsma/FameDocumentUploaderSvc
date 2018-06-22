using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc
{
    public partial class FameUploader : ServiceBase
    {
        public static FileSystemWatcher fameWatcher = new FileSystemWatcher(FameLibrary.cfgWatchDir);

        //Toggles the FileSystemWatcher monitoring
        public static void ToggleMonitoring(bool status)
        {

            if (status)
            {
                fameWatcher.EnableRaisingEvents = status;
                FameLibrary.LogEvent("FAME upload monitoring has successfully started", EventLogEntryType.Information);
                FameLibrary.WriteFameLog(" - FAME upload monitoring has successfully started");

            }
            else
            {

                fameWatcher.EnableRaisingEvents = status;
                FameLibrary.LogEvent("FAME upload monitoring has been stopped", EventLogEntryType.Warning);
                FameLibrary.WriteFameLog(" - FAME upload monitoring has been stopped.  No files will be uploaded until it has been restarted.");

            }

        }

        public FameUploader()
        {

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {


        //Create and start new thread for timer to allow program to wait for incoming files
        Thread timerThread = new Thread(new ThreadStart(FameLibrary.ExecuteWorkerThread));
            timerThread.Start();

            //Register the different types of file system events to listen for, Created, Changed, Renamed, Deleted
            //This launches the onChanged method we defined above.
            fameWatcher.Created += new FileSystemEventHandler(FameLibrary.OnChanged);

            //This begins the actual file monitoring
            ToggleMonitoring(true);

        }

        protected override void OnStop()
        {
            //Stop the file monitoring
            ToggleMonitoring(false);

        }
    }
}
