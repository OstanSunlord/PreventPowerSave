using ImNotAfkApp.CoreElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImNotAfkApp.Client
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            base.ForeColor = Themes.ForeColor;
            base.BackColor = Themes.BackColor;
        }
    }
}
