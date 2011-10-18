using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BoxedIce.ServerDensity.Agent.Tasks;

namespace BoxedIce.ServerDensity.Agent.ConfigWriter
{
    public class Worker
    {
        #region Properties

        public string Url { get; set; }
        public string AgentKey { get; set; }
        public bool IISChecks { get; set; }
        public string PluginDirectory { get; set; }
        public string MongoDBConnectionString { get; set; }
        public bool MongoDBDBStats { get; set; }
        public bool MongoDBReplSet { get; set; }
        public bool SQLServerStatus { get; set; }
        public string CustomPrefix { get; set; }
        public bool EventViewer { get; set; }
        
        #endregion

        /// <summary>
        /// Initialises a new instance of the <see cref="Worker"/> class with 
        /// the provided values.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agentKey">The agent key.</param>
        /// <param name="iisChecks">A value indicating whether or not to perform IIS checks.</param>
        /// <param name="pluginDirectory">The plugin directory.</param>
        /// <param name="mongoDBConnectionString">The MongoDB connection string.</param>
        /// <param name="sqlServerStatus">A value indicating whether or not to perform SQL Server checks.</param>
        public Worker(string url, string agentKey, bool iisChecks, string pluginDirectory, string mongoDBConnectionString, bool mongoDBDBStats, bool mongoDBReplSet, bool sqlServerStatus, string customPrefix, bool eventViewer)
        {
            Url = url;
            AgentKey = agentKey;
            IISChecks = iisChecks;
            PluginDirectory = pluginDirectory;
            MongoDBConnectionString = mongoDBConnectionString;
            MongoDBDBStats = mongoDBDBStats;
            MongoDBReplSet = mongoDBReplSet;
            SQLServerStatus = sqlServerStatus;
            CustomPrefix = customPrefix;
            EventViewer = eventViewer;

            _runner = new TaskRunner();
            _runner.AddTask(new WriteAgentConfigurationTask(
                new AgentConfiguration(Url, AgentKey, IISChecks, PluginDirectory, MongoDBConnectionString, MongoDBDBStats, MongoDBReplSet, SQLServerStatus, CustomPrefix, EventViewer)
            ));
            _runner.AddTask(new StopServiceTask());
            _runner.AddTask(new StartServiceTask());
            _runner.TaskCompleted += Runner_TaskCompleted;
        }

        private void Runner_TaskCompleted(object sender, TaskEventArgs e)
        {
            if (e.Task.GetType() == typeof(StopServiceTask))
            {
                OnServiceStopped(EventArgs.Empty);
            }
            else if (e.Task.GetType() == typeof(StartServiceTask))
            {
                OnServiceStarted(EventArgs.Empty);
            }
            else if (e.Task.GetType() == typeof(WriteAgentConfigurationTask))
            {
                OnConfigSaved(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Starts the config writing process.
        /// </summary>
        public void Start()
        {
            new Thread(new ThreadStart(Run)).Start();
        }

        private void Run()
        {
            try
            {
                _runner.Run();
                OnComplete(EventArgs.Empty);
            }
            catch
            {
                OnError(EventArgs.Empty);
            }
        }

        #region Event-raising methods
        private void OnConfigSaved(EventArgs e)
        {
            if (ConfigSaved == null)
            {
                return;
            }
            ConfigSaved(this, e);
        }

        private void OnServiceStopped(EventArgs e)
        {
            if (ServiceStopped == null)
            {
                return;
            }
            ServiceStopped(this, e);
        }

        private void OnServiceStarted(EventArgs e)
        {
            if (ServiceStarted == null)
            {
                return;
            }
            ServiceStarted(this, e);
        }

        private void OnComplete(EventArgs e)
        {
            Thread.Sleep(1000);
            if (Complete == null)
            {
                return;
            }
            Complete(this, e);
        }

        private void OnError(EventArgs e)
        {
            if (Error == null)
            {
                return;
            }
            Error(this, e);
        }
        #endregion

        private TaskRunner _runner;

        public event EventHandler ConfigSaved;
        public event EventHandler ServiceStopped;
        public event EventHandler ServiceStarted;
        public event EventHandler Complete;
        public event EventHandler Error;
    }
}
