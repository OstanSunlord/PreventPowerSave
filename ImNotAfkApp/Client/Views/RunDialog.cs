using ImNotAFK.Client.SystemTray.NotifyMenuItem;
using ImNotAFK.CoreElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImNotAFK.Client
{
    public partial class RunDialog : BaseDialog
    {
        public RunDialog()
        {
            InitializeComponent();

            UpdateStartAndStopButton();
            InitProgressBar(Controller.ConfigData.Interval * Controller.CurrentLogic.TickInterval);

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

        private void CurrentLogic_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateProgressBar();
        }

        private void CurrentLogic_Stoped(object sender, EventArgs e)
        {
            UpdateStartAndStopButton();            
        }

        private void CurrentLogic_Started(object sender, EventArgs e)
        {
            UpdateStartAndStopButton();
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
                InitProgressBar(Controller.ConfigData.Interval * Controller.CurrentLogic.TickInterval);
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

            lbEndTimeContext.Text = Controller.CurrentLogic.IsAlive ? Controller.CurrentLogic.EndDateTime.ToString() : string.Empty;
            lbStatusContext.Text = Controller.CurrentLogic.State.GetEnumDescription();

        }

        private void UpdateProgressBar()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { UpdateProgressBar(); });
            }
            else
            {
                if (pbWorkingStatus.Value < pbWorkingStatus.Maximum)
                {
                    pbWorkingStatus.Value += Controller.CurrentLogic.TickInterval;
                }
            }
        }

        private void InitProgressBar(int max) => InitProgressBar(0, max);
        private void InitProgressBar(int min, int max)
        {
            pbWorkingStatus.Minimum = min;
            pbWorkingStatus.Maximum = max - Controller.CurrentLogic.TickInterval;
            pbWorkingStatus.Value = 0;
        }

        private void ResetDisplay()
        {
            lbEndTimeContext.Text = Controller.CurrentLogic.IsAlive ? Controller.CurrentLogic.EndDateTime.ToString() : string.Empty;
            lbStatusContext.Text = Controller.CurrentLogic.State.GetEnumDescription();
            pbWorkingStatus.Value = 0;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Controller.ShowConfigurationDialog(FormStartPosition.CenterParent);
        }
    }
}

