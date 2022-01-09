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
    public partial class AddOrEditSchedulerDialog : BaseDialog
    {
        public AddOrEditSchedulerDialog(string text)
        {
            InitializeComponent();

            Text = text;

            Controller.ConfigData.ThemeChanged += ConfigData_ThemeChanged;

        }

        private void ConfigData_ThemeChanged(object sender, EventArgs e)
        {
            
        }

        public string Title
        {
            get => txTitle.Text;
            set => txTitle.Text = value;
        }

        public int Start
        {
            get => (int)nubStart.Value;
            private set => nubStart.Value = value;
        }

        public int End
        {
            get => (int)nubEnd.Value;
            private set => nubEnd.Value = value;
        }

        internal void SetStart(string start)
        {
            if(int.TryParse(start, out int value))
            {
                Start = value;
            }
        }

        internal void SetEnd(string end)
        {
            if (int.TryParse(end, out int value))
            {
                End = value;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                DialogResult = button.DialogResult;
                Close();
            }
        }

        private void VaildataInput()
        {
            if (string.IsNullOrEmpty(Title)) throw new Exception("Title can be Empty.");
            if(End < Start && End != 0) throw new Exception("Start and End can be the same.");
        }

        private void AddOrEditSchedulerDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    VaildataInput();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Vaildata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }

        }
    }
}
