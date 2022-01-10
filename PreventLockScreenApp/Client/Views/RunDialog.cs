using PreventLockScreen.Client.SystemTray.NotifyMenuItem;
using PreventLockScreen.CoreElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreventLockScreen.Client
{
    public partial class RunDialog : BaseDialog
    {
        public RunDialog()
        {
            InitializeComponent();
            
            UpdateStartAndStopButton();
            UpdateContext();
            InitProgressBar();

            Controller.CurrentLogic.Started += CurrentLogic_Started;
            Controller.CurrentLogic.Stoped += CurrentLogic_Stoped;
            Controller.CurrentLogic.Elapsed += CurrentLogic_Elapsed;

            ResetDisplay();   
        }

        public RunDialog(object sender) : this()
        {
            if(sender is ConfigurationNTCommand)
            {
                StartPosition = FormStartPosition.CenterParent;
            }
        }

        public string EndTime =>
            $"End Time: { Controller.CurrentLogic.EndDateTime.ToShortDateString()} { Controller.CurrentLogic.EndDateTime:HH:mm}";

        private void CurrentLogic_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateProgressBar();
        }

        private void CurrentLogic_Stoped(object sender, EventArgs e)
        {
            UpdateStartAndStopButton();
            UpdateContext();
        }

        private void CurrentLogic_Started(object sender, EventArgs e)
        {
            UpdateStartAndStopButton();
            UpdateContext();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bthStartAndStop_Click(object sender, EventArgs e)
        {
            if (Controller.CurrentLogic.IsAlive)
            {
                Controller.CurrentLogic.Stop();
            }
            else
            {
                Controller.CurrentLogic.Start(Controller.ConfigData.Interval);
                InitProgressBar();
            }
        }
        
        private void UpdateStartAndStopButton()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { UpdateStartAndStopButton(); });
            }
            else
            {
                bthStartAndStop.Text = Controller.CurrentLogic.IsAlive ? "Stop" : "Start";
            }
        }

        private void UpdateContext()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { UpdateContext(); });
            }
            else
            {
                lbEndTimeContext.Text = Controller.CurrentLogic.IsAlive ? EndTime : string.Empty;
                Text = $"{Controller.ScreenName} : {Controller.CurrentLogic.State.GetEnumDescription()}";
            }
        }

        private void UpdateProgressBar()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { UpdateProgressBar(); });
            }
            else
            {
            pbWorkingStatus.Value = pbWorkingStatus.Maximum < Controller.CurrentLogic.RunningTicks ? 
                    pbWorkingStatus.Maximum : Controller.CurrentLogic.RunningTicks;
            }
        }

        private void InitProgressBar() => InitProgressBar(Controller.CurrentLogic.TotalTickInterval);
        private void InitProgressBar(int max) => InitProgressBar(0, max);
        private void InitProgressBar(int min, int max)
        {
            pbWorkingStatus.Minimum = min;
            pbWorkingStatus.Maximum = max;
            pbWorkingStatus.Value = 0;
        }

        private void ResetDisplay()
        {
            UpdateContext();
            pbWorkingStatus.Value = 0;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Controller.ShowConfigurationDialog(FormStartPosition.CenterParent);
        }

        private void btnScheduler_Click(object sender, EventArgs e)
        {
            Controller.ShowSchedulerDialog(FormStartPosition.CenterParent);
        }
    }
}

