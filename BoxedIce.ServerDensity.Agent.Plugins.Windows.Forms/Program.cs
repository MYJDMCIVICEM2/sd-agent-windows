using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BoxedIce.ServerDensity.Agent.Plugins.Windows.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 11)
            {
                return;
            }

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
            string installKey = args[10];

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(agentKey, installKey, pluginDirectory, url, iisChecks, mongoDBConnectionString, mongoDBDBStats, mongoDBReplSet, sqlServerStatus, customPrefix, eventViewer));
        }
    }
}
