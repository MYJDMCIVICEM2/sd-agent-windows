using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BoxedIce.ServerDensity.Agent.Windows.Forms
{
    public partial class PluginForm : Form
    {
        public Button OK
        {
            get { return _ok; }
        }

        public TextBox InstallKey
        {
            get { return _installKey; }
        }

        public PluginForm()
        {
            InitializeComponent();
        }
    }
}
