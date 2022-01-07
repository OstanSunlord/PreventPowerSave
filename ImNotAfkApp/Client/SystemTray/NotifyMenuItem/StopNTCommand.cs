using ImNotAFK.CoreElements;
using System;
using System.Windows.Forms;

namespace ImNotAFK.Client.SystemTray.NotifyMenuItem
{
    internal class StopNTCommand : MenuItem
    {
        internal StopNTCommand() : base()
        {
            Text = "&Stop";
            Name = "Stop";
            Enabled = false;

            Click += StopNTCommand_Click;

            Controller.CurrentLogic.Started += CurrentKeepAlive_Started;
            Controller.CurrentLogic.Stoped += CurrentKeepAlive_Stoped;

        }

        private void CurrentKeepAlive_Stoped(object sender, EventArgs e)
        {
            Enabled = false;
        }

        private void CurrentKeepAlive_Started(object sender, EventArgs e)
        {
            Enabled = true;
        }

        private void StopNTCommand_Click(object sender, System.EventArgs e)
        {
            Controller.CurrentLogic.Stop();
        }
    }
}