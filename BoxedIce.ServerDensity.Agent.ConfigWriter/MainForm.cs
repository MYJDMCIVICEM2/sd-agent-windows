using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BoxedIce.ServerDensity.Agent.ConfigWriter
{
    public partial class MainForm : Form
    {
        public MainForm(Worker worker)
        {
            InitializeComponent();

            _worker = worker;
            _worker.Complete += new EventHandler(Worker_Complete);
            _worker.ConfigSaved += new EventHandler(Worker_ConfigSaved);
            _worker.ServiceStopped += new EventHandler(Worker_ServiceStopped);
            _worker.ServiceStarted += new EventHandler(Worker_ServiceStarted);
            _worker.Error += new EventHandler(Worker_Error);
        }

        private void Worker_ConfigSaved(object sender, EventArgs e)
        {
            UpdateProgress(30, "Stopping service...");
        }

        private void Worker_ServiceStopped(object sender, EventArgs e)
        {
            UpdateProgress(60, "Starting service...");
        }

        private void Worker_ServiceStarted(object sender, EventArgs e)
        {
            UpdateProgress(90, "Finalising configuration...");
        }

        private void Worker_Error(object sender, EventArgs e)
        {
            MessageBox.Show("There was an error saving the configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Invoke(new MethodInvoker(Close));
        }

        private void Worker_Complete(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(Close));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _worker.Start();
        }

        private void UpdateProgress(int value, string label)
        {
            Invoke(new MethodInvoker(delegate()
                {
                    _progress.Value = value;
                    _label.Text = label;
                })
            );
        }

        private readonly Worker _worker;
    }
}
