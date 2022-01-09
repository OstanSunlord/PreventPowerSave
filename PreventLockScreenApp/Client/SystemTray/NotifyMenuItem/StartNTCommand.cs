using ImNotAFK.CoreElements;
using System.Windows.Forms;

namespace ImNotAFK.Client.SystemTray.NotifyMenuItem
{
    internal class StartNTCommand : MenuItem
    {
        internal StartNTCommand() : base()
        {
            Text = "&Start";
            Name = "Start";
            Enabled = true;

            Click += StartNTCommand_Click;

            Controller.CurrentLogic.Started += CurrentKeepAlive_Started;
            Controller.CurrentLogic.Stoped += CurrentKeepAlive_Stoped;
        }

        private void CurrentKeepAlive_Stoped(object sender, System.EventArgs e)
        {
            Enabled = true;
        }

        private void CurrentKeepAlive_Started(object sender, System.EventArgs e)
        {
            Enabled = false;
        }

        private void StartNTCommand_Click(object sender, System.EventArgs e)
        {
            Controller.CurrentLogic.Start(Controller.ConfigData.Interval);
        }
    }
}