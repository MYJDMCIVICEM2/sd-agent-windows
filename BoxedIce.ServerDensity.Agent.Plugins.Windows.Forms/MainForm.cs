using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BoxedIce.ServerDensity.Agent.PluginSupport;

namespace BoxedIce.ServerDensity.Agent.Plugins.Windows.Forms
{
    public partial class MainForm : Form
    {
        public MainForm(string agentKey, string installKey, string pluginPath, string url, bool iisChecks, string mongoDBConnectionString, bool mongoDBDBStats, bool mongoDBReplSet, bool sqlServerStatus, string customPrefix, bool eventViewer)
        {
            _agentKey = agentKey;
            _installKey = installKey;
            _pluginPath = pluginPath;
            _url = url;
            _iisChecks = iisChecks;
            _mongoDBConnectionString = mongoDBConnectionString;
            _mongoDBDBStats = mongoDBDBStats;
            _mongoDBReplSet = mongoDBReplSet;
            _sqlServerStatus = sqlServerStatus;
            _customPrefix = customPrefix;
            _eventViewer = eventViewer;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WaitForParent();
            PluginInstallManager manager = new PluginInstallManager(_agentKey, _installKey, _pluginPath);
            manager.MetadataComplete += Manager_MetadataComplete;
            manager.DownloadComplete += Manager_DownloadComplete;
            manager.Error += Manager_Error;
            manager.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !_isComplete;
            base.OnClosing(e);
            if (e.Cancel)
            {
                return;
            }
            ProcessStartInfo info = new ProcessStartInfo(ConfigWriterExe);
            info.UseShellExecute = true;
            info.Verb = "runas";
            info.Arguments = string.Format("{0} \"{1}\" {2} \"{3}\" \"{4}\" {5} {6} {7} \"{8}\" {9}",
                _url,
                _agentKey,
                _iisChecks,
                _pluginPath,
                _mongoDBConnectionString,
                _mongoDBDBStats,
                _mongoDBReplSet,
                _sqlServerStatus,
                _customPrefix,
                _eventViewer);

            try
            {
                Process p = new Process();
                p.StartInfo = info;
                p.Start();
            }
            catch
            {
                MessageBox.Show("There was an error installing your plugin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Manager_MetadataComplete(object sender, EventArgs e)
        {
            _value += 50;
            _text = "Plugin information validated, downloading plugin...";
            BeginInvoke(new MethodInvoker(UpdateProgress));
        }

        private void Manager_DownloadComplete(object sender, EventArgs e)
        {
            _value += 50;
            _text = "Plugin installation complete!";
            _isComplete = true;
            BeginInvoke(new MethodInvoker(UpdateProgress));
            Close();
        }

        private void Manager_Error(object sender, ErrorEventArgs e)
        {
            _value = 100;
            _text = string.Format("Error encountered: {0}", e.Exception.Message);
            _isComplete = true;
            BeginInvoke(new MethodInvoker(UpdateProgress));
        }

        private void UpdateProgress()
        {
            _progress.Value = _value;
            _label.Text = _text;
            _close.Enabled = _isComplete;
        }

        private void WaitForParent()
        {
            while (true)
            {
                bool isFound = false;
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName.ToLower().Contains("boxedice.serverdensity.agent.windows.forms"))
                    {
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    return;
                }
                Thread.Sleep(1000);
            }
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        private readonly string _agentKey;
        private readonly string _installKey;
        private readonly string _pluginPath;
        private readonly string _url;
        private readonly bool _iisChecks;
        private readonly string _mongoDBConnectionString;
        private readonly bool _mongoDBDBStats;
        private readonly bool _mongoDBReplSet;
        private readonly bool _sqlServerStatus;
        private readonly string _customPrefix;
        private readonly bool _eventViewer;
        private int _value;
        private string _text;
        private bool _isComplete;
        private readonly string ConfigWriterExe = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BoxedIce.ServerDensity.Agent.ConfigWriter.exe");
    }
}
