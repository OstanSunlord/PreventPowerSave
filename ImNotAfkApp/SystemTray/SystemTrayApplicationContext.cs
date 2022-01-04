using System;
using System.Windows.Forms;

namespace ImNotAfkApp.SystemTray
{
    public class SystemTrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon m_trayIcon;
        private Configuration.ConfigurationView m_configurationView;

        public SystemTrayApplicationContext() =>

            m_trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.lightning,

                ContextMenu = new ContextMenu(
                    new MenuItem[] {
                        new MenuItem("Configuration", Config),
                        new MenuItem("-"),
                        new MenuItem("Exit", Exit)
                    }),
                Visible = true
            };

        private void Config(object sender, EventArgs e)
        {
            ShowConfiguration();
        }

        private void Exit(object sender, EventArgs e)
        {
            m_trayIcon.Visible = false;
            Application.Exit();
        }

        private void ShowConfiguration() =>
            ShowConfiguration(true);

        private void ShowConfiguration(bool firstRun)
        {
            try
            {
                if (m_configurationView == null)
                {
                    m_configurationView = new Configuration.ConfigurationView("I'm Not AFK - Configuration")
                    {
                        Icon = Properties.Resources.lightning
                    };
                }

                m_configurationView.Show();
                m_configurationView.Focus();
            }
            catch (ObjectDisposedException e)
            {
                m_configurationView = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (!firstRun) throw e;
                ShowConfiguration(false);
                return;
            }
        }
    }
}
