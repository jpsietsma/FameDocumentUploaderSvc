using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private Timer workerTimer = null;

        public FameUploader()
        {

            InitializeComponent();
        }

        //Actions performed when timer elapses.
        private void WorkerTimer_Tick(object sender, ElapsedEventArgs e)
        {
            //Currently does nothing, but we could add emailing here if conditions are met for hourly/daily mailings
        }

        protected override void OnStart(string[] args)
        {

            //Create and start our timer
            workerTimer = new Timer();
            this.workerTimer.Interval = 30000;
            this.workerTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.WorkerTimer_Tick);
            workerTimer.Enabled = true;

            //Register the different types of file system events to listen for, Created, Changed, Renamed, Deleted
            //This launches the onChanged method we defined above.
            fameWatcher.Created += new FileSystemEventHandler(FameLibrary.OnChanged);

            //This begins the actual file monitoring
            FameLibrary.ToggleMonitoring(true, fameWatcher);

        }

        protected override void OnStop()
        {
            //Stop the file monitoring
            FameLibrary.ToggleMonitoring(false, fameWatcher);

            //Stop the timer thread
            workerTimer.Enabled = false;
        }
    }
}
