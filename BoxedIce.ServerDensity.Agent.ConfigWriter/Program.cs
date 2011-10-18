using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BoxedIce.ServerDensity.Agent;

namespace BoxedIce.ServerDensity.Agent.ConfigWriter
{
    public class ConfigWriter
    {
        private static void Main(string[] args)
        {
            if (args.Length != 10)
            {
                return;
            }

            try
            {
                string url = args[0];
                string agentKey = args[1];
                bool iisChecks = Convert.ToBoolean(args[2]);
                string pluginDirectory = args[3];
                string mongoDBConnectionString = args[4];
                bool mongoDBDBStats = Convert.ToBoolean(args[5]);
                bool mongoDBReplSet = Convert.ToBoolean(args[6]);
                bool sqlServerStatus = Convert.ToBoolean(args[7]);
                string customPrefix = args[8];
                bool eventViewer = Convert.ToBoolean(args[9]);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Worker worker = new Worker(url, agentKey, iisChecks, pluginDirectory, mongoDBConnectionString, mongoDBDBStats, mongoDBReplSet, sqlServerStatus, customPrefix, eventViewer);
                Application.Run(new MainForm(worker));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
