using System;
using System.Windows.Forms;
using ImNotAfkApp.Client.SystemTray;
using ImNotAfkApp.CoreElements;
using Microsoft.Win32;

namespace ImNotAfkApp.Client
{
    public partial class SplashScreen : Form
    {
        KeyboardHook hook = new KeyboardHook();

        private Timer waitTimer;

        public SplashScreen()
        {
            InitializeComponent();

            hook.KeyPressed += Hook_KeyPressed;

            hook.RegisterHotKey(CoreElements.ModifierKeys.Control | CoreElements.ModifierKeys.Alt,
            Keys.S);

        }

        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Controller.CurrentLogic.SwitchState(Controller.ConfigData.Interval);
        }

        #region Properties 

        public NotifyIcon QuickMenu { get; set; }

        #endregion

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
            waitTimer.Stop();

            Controller.ConfigData.RunOnStartUpChanged += ConfigData_RunOnStartUpChanged;
            Controller.ConfigData.RunInSystemTrayChanged += ConfigData_RunInSystemTrayChanged;
            Controller.ConfigData.Load();

            this.Hide();

            if (Controller.ConfigData.RunInSystemTray)
            {
                QuickMenu = NotifyIconLogic.GetNotify();
            }
            else
            {
                new RunDialog().ShowDialog();
                Application.Exit();
            }
        }

        private void ConfigData_RunInSystemTrayChanged(object sender, EventArgs e)
        {
            if(sender is ConfigData config)
            {
                if(MessageBox.Show(this, "Do you want restart the program to activate the change?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    config.Save();
                    Application.Restart();
                }
            }
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


    }
}
