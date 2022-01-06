using ImNotAfkApp.CoreElements;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImNotAfkApp.Client.SystemTray.NotifyMenuItem
{
    internal class ConfigurationNTCommand : MenuItem
    {
        internal ConfigurationNTCommand() : base()
        {
            Text = "&Configuration";
            Name = "Config";
            Click += ConfigurationNTCommand_Click;
        }

        private void ConfigurationNTCommand_Click(object sender, EventArgs e)
        {
            Controller.ShowConfigurationDialog(FormStartPosition.CenterScreen);
        }
    }
}
