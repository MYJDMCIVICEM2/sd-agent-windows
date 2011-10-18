using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BoxedIce.ServerDensity.Agent.Windows.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool runMinimized = false;

            if (args.Length == 1 && args[0] == "/minimized")
            {
                runMinimized = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(runMinimized));
        }
    }
}
