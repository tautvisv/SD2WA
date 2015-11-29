using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using MatchParserServices;
using Timer = System.Timers.Timer;

namespace MatcheParserService
{

    public partial class MatchParserService : ServiceBase
    {
        private int _eventId;
        private readonly ITasksParser _tasksParser;
        //public MatchParserService()
        //{
        //    InitializeComponent();
        //    eventLog1 = new System.Diagnostics.EventLog();
        //    if (!System.Diagnostics.EventLog.SourceExists("MySource"))
        //    {
        //        System.Diagnostics.EventLog.CreateEventSource(
        //            "MySource", "MyNewLog");
        //    }
        //    eventLog1.Source = "MySource";
        //    eventLog1.Log = "MyNewLog";
        //}

        public MatchParserService(ITasksParser tasksParser)
        {
            _tasksParser = tasksParser;
            InitializeComponent(); 
            //string eventSourceName = "MySource"; 
            //string logName = "MyNewLog";
            //if (args.Count() > 0)
            //{
            //    eventSourceName = args[0];
            //}
            //if (args.Count() > 1)
            //{
            //    logName = args[1];
                
            //} eventLog1 = new EventLog();
            //if (!EventLog.SourceExists(eventSourceName))
            //{
            //    EventLog.CreateEventSource(eventSourceName, logName);
            //} 
            //eventLog1.Source = eventSourceName; eventLog1.Log = logName;
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            while (true)
            {
                _tasksParser.ParserTask();
                Thread.Sleep(1000);
            }
           
            //instantiate timer
            //Thread t = new Thread(new ThreadStart(this.DoStuff));
            //t.Start();
            //LaunchTimer();

        }

        public void LaunchTimer()
        {

            //System.IO.File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt", new []{"In OnStart"});
            // Set up a timer to trigger every minute.
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 600; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();


        }
        protected override void OnStop()
        {
            using (var a = System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt"))
            {

            };
            //System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt");
           // eventLog1.WriteEntry("In onStop.");
        }
        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, _eventId++);
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);
    }
}
