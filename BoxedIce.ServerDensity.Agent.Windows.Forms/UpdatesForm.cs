using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BoxedIce.ServerDensity.Agent.Windows.Forms
{
    public partial class UpdatesForm : Form
    {
        [DllImport("user32")]
        public static extern UInt32 SendMessage(IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);

        internal const int BCM_FIRST = 0x1600; //Normal button

        internal const int BCM_SETSHIELD = (BCM_FIRST + 0x000C); //Elevated button

        public bool DoNotShowAgain
        {
            get { return _doNotShow.Checked; }
        }

        public UpdatesForm()
        {
            InitializeComponent();

            try
            {
                _ok.FlatStyle = FlatStyle.System;
                SendMessage(_ok.Handle, BCM_SETSHIELD, 0, 0xFFFFFFFF);
            }
            catch
            {
            }
        }
    }
}
