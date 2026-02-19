using PreventPowerSave.Client.SystemTray.NotifyMenuItem;
using PreventPowerSave.CoreElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreventPowerSave.Client
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Subscribe after AButton.OnCreateControl so our handler runs last and wins
            Controller.ConfigData.ThemeChanged += (s, ev) => UpdateStartAndStopButton();
            UpdateStartAndStopButton();
        }

        public string EndTime => Controller.CurrentLogic.IsEndless
            ? "Endless mode"
            : $"End Time: {Controller.CurrentLogic.EndDateTime.ToShortDateString()} {Controller.CurrentLogic.EndDateTime:HH:mm}";

        private void CurrentLogic_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateProgressBar();
        }

        private void CurrentLogic_Stoped(object sender, EventArgs e)
        {
            UpdateStartAndStopButton();
            UpdateContext();
            ResetProgressBar();
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
            if (Controller.CurrentLogic.State == CoreElements.State.PROGRAM_STATE.Running)
            {
                Controller.CurrentLogic.Stop();
            }
            else
            {
                if (Controller.ConfigData.EndlessMode)
                    Controller.CurrentLogic.StartEndless();
                else
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
                bool running = Controller.CurrentLogic.State == CoreElements.State.PROGRAM_STATE.Running;
                bthStartAndStop.Text = running ? "■  Stop" : "▶  Start";
                bthStartAndStop.BackColor = running
                    ? Color.FromArgb(180, 40, 40)
                    : Color.FromArgb(40, 150, 70);
                bthStartAndStop.ForeColor = Color.White;
                bthStartAndStop.FlatAppearance.BorderColor = running
                    ? Color.FromArgb(140, 20, 20)
                    : Color.FromArgb(20, 110, 50);
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
                lbEndTimeContext.Text = Controller.CurrentLogic.State == CoreElements.State.PROGRAM_STATE.Running  ? EndTime : string.Empty;
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
                if (Controller.CurrentLogic.IsEndless) return;
                pbWorkingStatus.Value = pbWorkingStatus.Maximum < Controller.CurrentLogic.RunningTicks
                    ? pbWorkingStatus.Maximum
                    : Controller.CurrentLogic.RunningTicks;
            }
        }

        private void InitProgressBar()
        {
            if (Controller.CurrentLogic.IsEndless)
            {
                pbWorkingStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
                pbWorkingStatus.MarqueeAnimationSpeed = 30;
            }
            else
            {
                pbWorkingStatus.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
                pbWorkingStatus.Minimum = 0;
                pbWorkingStatus.Maximum = Controller.CurrentLogic.TotalTickInterval;
                pbWorkingStatus.Value = 0;
            }
        }

        private void ResetProgressBar()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { ResetProgressBar(); });
            }
            else
            {
                pbWorkingStatus.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
                pbWorkingStatus.Minimum = 0;
                pbWorkingStatus.Maximum = 100;
                pbWorkingStatus.Value = 0;
            }
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

