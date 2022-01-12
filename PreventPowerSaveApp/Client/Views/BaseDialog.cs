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
    public partial class BaseDialog : Form
    {
        public BaseDialog()
        {
            Controller.ConfigData.ThemeChanged += ConfigData_ThemeChanged;

            Icon = Properties.Resources.lightning;

            UpdateTheme();
        }

        private void ConfigData_ThemeChanged(object sender, EventArgs e)
        {
            UpdateTheme();
        }

        private void UpdateTheme()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { UpdateTheme(); });
            }
            else
            {
                base.ForeColor = Themes.ForeColor;
                base.BackColor = Themes.BackColor;
            }
        }
    }
}
