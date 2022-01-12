using PreventPowerSave.CoreElements;
using PreventPowerSave.CoreElements.State;
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
    public partial class SchedulerDialog : BaseDialog
    {
        public SchedulerDialog(string text)
        {
            InitializeComponent();
            Text = text;

            Controller.ConfigData.ThemeChanged += ConfigData_ThemeChanged;

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

            //dgvScheduler.DefaultCellStyle.SelectionBackColor = Controller.ConfigData.ThemeMode != THEMEMODE_STATE.DarkMode ? SystemColors.ControlDark : Color.White;
            //dgvScheduler.DefaultCellStyle.SelectionForeColor = Controller.ConfigData.ThemeMode != THEMEMODE_STATE.DarkMode ? Color.White : SystemColors.ControlDark;
            //dgvScheduler.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Yellow;

            dgvScheduler.RowsDefaultCellStyle.BackColor = Controller.ConfigData.ThemeMode == THEMEMODE_STATE.DarkMode ? SystemColors.ControlDark : Color.White;
            dgvScheduler.AlternatingRowsDefaultCellStyle.BackColor = Controller.ConfigData.ThemeMode == THEMEMODE_STATE.DarkMode ? SystemColors.ControlDark : Color.White;

            dgvScheduler.ColumnHeadersDefaultCellStyle.ForeColor = Controller.ConfigData.ThemeMode != THEMEMODE_STATE.DarkMode ? Color.White : Color.Black;
            dgvScheduler.ColumnHeadersDefaultCellStyle.BackColor = Controller.ConfigData.ThemeMode == THEMEMODE_STATE.DarkMode ? Color.White : Color.Black;
            dgvScheduler.RowHeadersDefaultCellStyle.BackColor = Controller.ConfigData.ThemeMode == THEMEMODE_STATE.DarkMode ? Color.White : Color.Black; ;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrEditSchedulerDialog dialog = new AddOrEditSchedulerDialog("Add Schedule")
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (dialog.ShowDialog() == DialogResult.Yes)
            {
                int start = dialog.Start;
                int end = dialog.End;
                if (start == end && start == 0) end = 24;
                if (start == end && start != 24) end++;
                if (start == end && start != 0) start--;

                dgvScheduler.Rows.Add(dialog.Title, start, end);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvScheduler.SelectedRows.Count > 0)
            {
                AddOrEditSchedulerDialog dialog = new AddOrEditSchedulerDialog("Edit Schedule")
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                dialog.Title = dgvScheduler.SelectedRows[0].Cells[0].Value.ToString();
                dialog.SetStart(dgvScheduler.SelectedRows[0].Cells[1].Value.ToString());
                dialog.SetEnd(dgvScheduler.SelectedRows[0].Cells[2].Value.ToString());

                if (dialog.ShowDialog() == DialogResult.Yes)
                {
                    dgvScheduler.SelectedRows[0].Cells[0].Value = dialog.Title;
                    dgvScheduler.SelectedRows[0].Cells[1].Value = dialog.Start;
                    dgvScheduler.SelectedRows[0].Cells[2].Value = dialog.End;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvScheduler.SelectedRows.Count > 0)
            {
                dgvScheduler.Rows.Remove(dgvScheduler.SelectedRows[0]);
            }
        }
    }
}
