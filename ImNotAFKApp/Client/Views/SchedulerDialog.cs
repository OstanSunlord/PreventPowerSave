using ImNotAFK.CoreElements;
using ImNotAFK.CoreElements.State;
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
    public partial class SchedulerDialog : BaseDialog
    {
        private ConfigData _configData;

        public SchedulerDialog(ConfigData configData, string text)
        {
            InitializeComponent();
            Text = text;

            _configData = configData;

            configData.ThemeChanged += ConfigData_ThemeChanged;

            ChangeTheme();
            InitCells();
        }

        private void InitCells()
        {
            foreach (var item in Controller.Schedulers)
            {
                dgvScheduler.Rows.Add(item.Title, item.Start, item.End);
            }
        }

        private void ConfigData_ThemeChanged(object sender, EventArgs e)
        {
            ChangeTheme();
        }

        private void ChangeTheme()
        {
            dgvScheduler.BackgroundColor = SystemColors.AppWorkspace;

            dgvScheduler.DefaultCellStyle.SelectionBackColor = _configData.ThemeMode == THEMEMODE_STATE.DarkMode ? SystemColors.ControlDark : Color.White;
            dgvScheduler.DefaultCellStyle.SelectionForeColor = _configData.ThemeMode == THEMEMODE_STATE.DarkMode ? Color.White : SystemColors.ControlDark;
            dgvScheduler.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            dgvScheduler.RowsDefaultCellStyle.BackColor = _configData.ThemeMode == THEMEMODE_STATE.DarkMode ? SystemColors.ControlDark : Color.White;
            dgvScheduler.AlternatingRowsDefaultCellStyle.BackColor = _configData.ThemeMode == THEMEMODE_STATE.DarkMode ? SystemColors.ControlDark : Color.White;

            dgvScheduler.ColumnHeadersDefaultCellStyle.ForeColor = _configData.ThemeMode != THEMEMODE_STATE.DarkMode ? Color.White : Color.Black;
            dgvScheduler.ColumnHeadersDefaultCellStyle.BackColor = _configData.ThemeMode == THEMEMODE_STATE.DarkMode ? Color.White : Color.Black;
            dgvScheduler.RowHeadersDefaultCellStyle.BackColor = _configData.ThemeMode == THEMEMODE_STATE.DarkMode ? Color.White : Color.Black; ;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                DialogResult = button.DialogResult;
                Close();
            }
        }

        private void btnAmend_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                DialogResult = button.DialogResult;
                Close();
            }
        }

        public List<SchedulerItem> GetSchedulerList()
        {
            List<SchedulerItem> list = new List<SchedulerItem>();
            foreach (DataGridViewRow row in dgvScheduler.Rows)
            {
                if (row.Cells[1].Value == null) continue;
                if (!int.TryParse(row.Cells[1].Value.ToString(), out int start)) start = 0;
                if (!int.TryParse(row.Cells[2].Value.ToString(), out int end)) end = 0;

                if (start < 0 || start > 23) start = 0;
                if (end > 24 || end == 0) end = 24;
                if (start == end && start == 0) end = 24;
                if (list.Any(x => x.Start == start && x.End == end)) continue;

                list.Add(new SchedulerItem()
                {
                    Title = row.Cells[0].Value.ToString(),
                    Start = start,
                    End = end
                });

            }

            return list;
        }
    }
}
