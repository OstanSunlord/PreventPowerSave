using ImNotAfkApp.Configuration;
using System;
using System.Windows.Forms;

namespace ImNotAfkApp.SystemTray
{
    public class SystemTrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon m_trayIcon;
        private ConfigurationView m_configurationView;
        private static ConfigData m_configData;

        private KeepAliveLogic m_currentKeepAlive;
        private MainContextMenu m_contextMenu;

        public SystemTrayApplicationContext()
        {
            m_configData = new ConfigData().Load();
            m_currentKeepAlive = new KeepAliveLogic();

            m_currentKeepAlive.Started += CurrentKeepAlive_Started;
            m_currentKeepAlive.Stoped += CurrentKeepAlive_Stoped;

            m_contextMenu = new MainContextMenu(
                    new MenuItem[] {
                        CommandStatusMenuItem(),
                        new MenuItem("-"),
                        CommandStartMenuItem(),
                        CommandStopMenuItem(),
                        new MenuItem("-"),
                        new MenuItem("Configuration", Config),
                        new MenuItem("-"),
                        new MenuItem("Exit", Exit)
                    });

            m_trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.lightning,

                ContextMenu = m_contextMenu,
                Visible = true
            };
        }

        private void CurrentKeepAlive_Stoped(object sender, EventArgs e)
        {
            UpdateMenuItems();
        }

        private void CurrentKeepAlive_Started(object sender, EventArgs e)
        {
            UpdateMenuItems();
        }

        private void UpdateMenuItems()
        {
           foreach(MenuItem item in m_contextMenu.MenuItems)
            {
                switch (item.Name)
                {
                    case "btnHeader":
                        item.Text = $"I'm not AFK <{m_currentKeepAlive.State}>";
                        break;
                    case "btnStart":
                        item.Enabled = !m_currentKeepAlive.IsAlive;
                        break;
                    case "btnStop":
                        item.Enabled = m_currentKeepAlive.IsAlive;
                        break;
                }
            }
        }

        private MenuItem CommandStatusMenuItem()
        {
            var item = new MenuItem()
            {
                Text = $"I'm not AFK <{m_currentKeepAlive.State}>",
                Name = "btnHeader"
            };
            return item;
        }

        private MenuItem CommandStartMenuItem()
        {
            var item = new MenuItem()
            {
                Text = "Start",
                Enabled = !m_currentKeepAlive.IsAlive,
                Name = "btnStart"

            };

            item.Click += Start;
            return item;
        }

        private MenuItem CommandStopMenuItem()
        {
            var item = new MenuItem()
            {
                Text = "Stop",
                Enabled = m_currentKeepAlive.IsAlive,
                Name = "btnStop"
            };

            item.Click += Stop;
            return item;
        }

        private void Stop(object sender, EventArgs e)
        {
            m_currentKeepAlive.Stop();
        }

        private void Start(object sender, EventArgs e)
        {
            m_currentKeepAlive.Start(m_configData.Interval);
        }

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
                    m_configurationView = new ConfigurationView(m_configData, "I'm Not AFK - Configuration")
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
