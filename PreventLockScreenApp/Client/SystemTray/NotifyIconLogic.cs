using PreventLockScreen.CoreElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreventLockScreen.Client.SystemTray
{
    public class NotifyIconLogic
    {
        private static NotifyIcon _trayIcon;

        public NotifyIconLogic()
        {

        }

        public static NotifyIcon GetNotify(string text)
        {
            if (_trayIcon == null)
            {
                _trayIcon = new NotifyIcon()
                {
                    Icon = Properties.Resources.lightning,
                    ContextMenu = GetContextMenu(),
                    Text = text
                };
                _trayIcon.Click += TrayIcon_Click;
            }

            _trayIcon.Visible = true;
            return _trayIcon;
        }

        private static void TrayIcon_Click(object sender, EventArgs e)
        {
            Controller.ShowRunDialog(sender);
        }

        private static ContextMenu GetContextMenu()
        {
            var contextMenu = new ContextMenu(
            new MenuItem[] {
                new NotifyMenuItem.StatusNTCommand(),
                new MenuItem("-"),
                new NotifyMenuItem.StartNTCommand(),
                new NotifyMenuItem.StopNTCommand(),
                new MenuItem("-"),
                new NotifyMenuItem.SchedulerNTCommand(),
                new NotifyMenuItem.ConfigurationNTCommand(),
                new MenuItem("-"),
                new MenuItem("Exit", Exit)

            });

            return contextMenu;
        }

        private static void Exit(object sender, EventArgs e)
        {
            Controller.CurrentLogic.Stop();
            _trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
