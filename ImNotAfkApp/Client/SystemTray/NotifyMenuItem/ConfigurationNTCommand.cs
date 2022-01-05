using ImNotAfkApp.Client.Configuration;
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
            ShowConfiguration();
        }

        private void ShowConfiguration() =>
            ShowConfiguration(true);

        private void ShowConfiguration(bool firstRun)
        {
            try
            {
                if (Controller.ConfigurationDialog == null)
                {
                    Controller.ConfigurationDialog = new ConfigurationDialog(Controller.ConfigData, "Configuration")
                    {
                        Icon = Properties.Resources.lightning
                    };
                }

                if (Controller.ConfigurationDialog.ShowDialog() == DialogResult.Yes)
                {
                    Controller.ConfigData.SetInterval(Controller.ConfigurationDialog.InterVal);
                    Controller.ConfigData.SetThemeMode(Controller.ConfigurationDialog.ThemeMode);
                    Controller.ConfigData.SetRunOnStartUp(Controller.ConfigurationDialog.RunOnStartUp);
                    Controller.ConfigData.Save();
                }
                Controller.ConfigurationDialog.Focus();
            }
            catch (ObjectDisposedException e)
            {
                Controller.ConfigurationDialog = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (!firstRun) throw e;
                ShowConfiguration(false);
                return;
            }
        }
    }
}
