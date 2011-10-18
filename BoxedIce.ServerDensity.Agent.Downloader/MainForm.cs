using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Threading;
using System.Diagnostics;

namespace BoxedIce.ServerDensity.Agent.Downloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Initialise the update checker and set up its events.
            _updater = new Updater();
            _updater.UpdatesDetected += Updater_UpdatesDetected;
            _updater.Complete += Updater_NoUpdatesDetected;
            _updater.Error += Updater_Error;

            WaitForParent(); // Wait for parent process to die.

            // Start the update checker.
            _updater.Start();
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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if ((_updater != null && _updater.IsRunning) ||
                (_downloader != null && _downloader.IsRunning))
            {
                e.Cancel = true;
            }
        }

        private void Updater_UpdatesDetected(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(StartDownloads));
        }

        private void Updater_NoUpdatesDetected(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(NoUpdates));
        }

        private void Updater_Error(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(Error));
        }

        private void Downloader_ProgressUpdated(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(UpdateProgress));
        }

        private void Downloader_Complete(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(Complete));
        }

        private void Downloader_Error(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(Error));
        }

        private void Error()
        {
            if (_downloader != null && _downloader.IsRunning)
            {
                _downloader.Stop();
            }
            
            if (_updater != null && _updater.IsRunning)
            {
                _updater.Stop();
            }

            try
            {
                StartService();
            }
            catch
            {
            }

            MessageBox.Show("There was an error downloading updates. Please ensure that you are an administrator or that this was run with properly elevated privileges.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        private void StartDownloads()
        {
            try
            {
                StopService();
            }
            catch
            {
                Error();
                return;
            }
            finally
            {
                _updater.Stop();
            }

            // Initialise our downloader with the updated file collection.
            _downloader = new UpdateDownloader(_updater.Files);

            // Set up the downloader events.
            _downloader.ProgressUpdated += Downloader_ProgressUpdated;
            _downloader.Complete += Downloader_Complete;
            _downloader.Error += Downloader_Error;

            // Begin downloading.
            _label.Text = string.Format("Downloading {0}...", _downloader.CurrentFile.Key);
            _downloader.Start();
        }

        private void UpdateProgress()
        {
            Invoke(new MethodInvoker(delegate()
                {
                    _progress.Value = (int)_downloader.Percentage;
                    _label.Text = string.Format("Downloading {0}...", _downloader.CurrentFile.Key);
                })
            );
        }

        private void Complete()
        {
            _label.Text = "Downloading complete!";
            _close.Enabled = true;
            StartService();
        }

        private void NoUpdates()
        {
            _updater.Stop();
            _label.Text = "No updates to download.";
            _close.Enabled = true;
        }

        private void StopService()
        {
            using (ServiceController service = new ServiceController(ServiceName))
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));
                service.Close();
            }
        }

        private void StartService()
        {
            using (ServiceController service = new ServiceController(ServiceName))
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
                service.Close();
            }
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        private const string ServiceName = "Server Density Monitoring Agent";
        private Updater _updater;
        private UpdateDownloader _downloader;
    }
}
