using System;
using System.Windows.Forms;
using ImNotAfkApp.Client.SystemTray;
using ImNotAfkApp.CoreElements;
using Microsoft.Win32;

namespace ImNotAfkApp.Client
{
    public partial class SplashScreen : Form
    {
        private Timer waitTimer;

        public SplashScreen()
        {
            InitializeComponent();
        }

        public NotifyIcon QuickMenu { get; set; }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            waitTimer = new Timer()
            {
                Interval = 2000,
                Enabled = true
            };

            waitTimer.Tick += WaitTimer_Tick;
        }

        private void WaitTimer_Tick(object sender, EventArgs e)
        {
            Controller.ConfigData.Loaded += ConfigData_Loaded;
            Controller.ConfigData.RunOnStartUpChanged += ConfigData_RunOnStartUpChanged;
            Controller.ConfigData.Load();
            waitTimer.Stop();
        }

        private void ConfigData_RunOnStartUpChanged(object sender, EventArgs e)
        {
            string AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                (@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (Controller.ConfigData.RunOnStartUp)
            {
                rk.SetValue(AppName, Application.ExecutablePath);
            }
            else
            {
                rk.DeleteValue(AppName, false);
            }
        }

        private void ConfigData_Loaded(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => ConfigData_Loaded(sender, e)));
            }
            else
            {
                this.Hide();
                QuickMenu = NotifyIconLogic.GetNotify();
            }
        }
    }
}
