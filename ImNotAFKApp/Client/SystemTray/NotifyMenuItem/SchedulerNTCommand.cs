using ImNotAFK.CoreElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImNotAFK.Client.SystemTray.NotifyMenuItem
{
    internal class SchedulerNTCommand : MenuItem
    {
        internal SchedulerNTCommand() : base()
        {
            Text = "&Scheduler";
            Name = "Scheduler";
            Click += SchedulerNTCommand_Click;
        }

        private void SchedulerNTCommand_Click(object sender, EventArgs e)
        {
            Controller.ShowSchedulerDialog(FormStartPosition.CenterScreen);
        }
    }
}
