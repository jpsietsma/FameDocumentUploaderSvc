using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace FameDocumentUploaderSvc
{
    public partial class FameUploader : ServiceBase
    {
        public FileSystemWatcher fameWatcher = new FileSystemWatcher(Configuration.cfgWatchDir);
        private Timer WorkerTimer = null;
        private Timer MailTimer = null;

        public FameUploader()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when the windows service is started
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {

            //Create and start new thread for timer to allow program to wait for incoming files
            WorkerTimer = new Timer(Configuration.cfgWorkerInterval);

            //Timer to control mailflow, default every 30 minutes
            Timer MailTimer = new Timer(Configuration.cfgMailTimer);

            //Register events to listen for: Created only
            fameWatcher.Created += new FileSystemEventHandler(FameLibrary.OnFileDropped);

            //Check log messages at predefined intervals and send emails if necessary.            
            MailTimer.Elapsed += new ElapsedEventHandler(FameLibrary.MailTimer_Tick);


            //This begins the actual file monitoring
            FameLibrary.ToggleMonitoring(true, fameWatcher);
            WorkerTimer.Start();
            MailTimer.Start();

        }

        /// <summary>
        /// Occurs when stopping the windows service
        /// </summary>
        protected override void OnStop()
        {

            FameLibrary.ToggleMonitoring(false, fameWatcher);
            WorkerTimer.Stop();
            MailTimer.Stop();
        }

        /// <summary>
        /// Occurs when pausing the windows service
        /// </summary>
        protected override void OnPause()
        {
            FameLibrary.ToggleMonitoring(false, fameWatcher);
            WorkerTimer.Stop();
            MailTimer.Stop();
        }

        /// <summary>
        /// Occurs when resuming the windows service from a paused state
        /// </summary>
        protected override void OnContinue()
        {
            FameLibrary.ToggleMonitoring(true, fameWatcher);
            WorkerTimer.Start();
            MailTimer.Start();

        }

        /// <summary>
        /// Occurs when windows is shutting down
        /// </summary>
        protected override void OnShutdown()
        {
            FameLibrary.ToggleMonitoring(false, fameWatcher);
            MailTimer.Stop();
            WorkerTimer.Stop();
        }
    }
}
