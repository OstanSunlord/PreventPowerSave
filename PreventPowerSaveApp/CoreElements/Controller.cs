using PreventPowerSave.Client;
using PreventPowerSave.Client.SystemTray.NotifyMenuItem;
using System;
using System.Windows.Forms;

namespace PreventPowerSave.CoreElements
{
    public static class Controller
    {
        public const string ScreenName = "Prevent PowerSave";

        public static ConfigData ConfigData { get; set; } = new ConfigData();
        public static ConfigurationDialog ConfigurationDialog { get; set; } = null;
        public static SchedulerCollection Schedulers { get; set; } = new SchedulerCollection();
        public static SchedulerDialog SchedulerDialog { get; set; } = null;
        public static RunDialog RunDialog { get; set; } = null;
        public static CurrentLogic CurrentLogic { get; } = new CurrentLogic();

        public static void ShowConfigurationDialog(FormStartPosition formStartPosition) =>
            ShowConfigurationDialog(formStartPosition, true);

        private static void ShowConfigurationDialog(FormStartPosition formStartPosition, bool firstRun)
        {
            try
            {
                if (ConfigurationDialog == null)
                {
                    ConfigurationDialog = new ConfigurationDialog(ConfigData, "Configuration")
                    {
                        StartPosition = formStartPosition
                    };
                }

                if (ConfigurationDialog.ShowDialog() == DialogResult.Yes)
                {
                    ConfigData.SetInterval(ConfigurationDialog.InterVal);
                    ConfigData.SetThemeMode(ConfigurationDialog.ThemeMode);
                    ConfigData.SetRunOnStartUp(ConfigurationDialog.RunOnStartUp);
                    ConfigData.SetRunInSystemTray(ConfigurationDialog.RunInSystemTray);
                    ConfigData.Save();
                }

                ConfigurationDialog.Dispose();
            }
            catch (ObjectDisposedException e)
            {
                ConfigurationDialog = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (!firstRun) throw e;
                ShowConfigurationDialog(formStartPosition, false);
                return;
            }
        }

        internal static void ShowSchedulerDialog(FormStartPosition formStartPosition)
             => ShowSchedulerDialog(formStartPosition, true);
        private static void ShowSchedulerDialog(FormStartPosition formStartPosition, bool firstRun)
        {
            try
            {
                if(SchedulerDialog == null)
                {
                    SchedulerDialog = new SchedulerDialog("Time Scheduler")
                    {
                        StartPosition = formStartPosition
                    };
                }

                if(SchedulerDialog.ShowDialog() == DialogResult.Yes)
                {
                    Schedulers.Override(SchedulerDialog.GetSchedulerList());
                    ConfigData.SetScheduler(Schedulers.GetConfigString());
                    ConfigData.Save();
                }

                SchedulerDialog.Dispose();
            }
            catch(ObjectDisposedException e)
            {
                SchedulerDialog = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (!firstRun) throw e;
                ShowSchedulerDialog(formStartPosition, false);
            }
        }


        internal static void ShowRunDialog(object sender) =>
            ShowRunDialog(sender, true);
        internal static void ShowRunDialog(object sender, bool firstRun)
        {
            try
            {
                if (RunDialog == null)
                {
                    RunDialog = new RunDialog(sender);
                    RunDialog.ShowDialog();
                    RunDialog = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                else
                {
                    RunDialog.Focus();
                }
            }
            catch (ObjectDisposedException e)
            {
                RunDialog = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (!firstRun) throw e;
                ShowRunDialog(sender, false);
                return;
            }
        }
    }
}
