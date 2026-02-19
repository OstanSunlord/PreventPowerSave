using PreventPowerSave.CoreElements;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PreventPowerSave.Client
{
    public partial class BaseDialog : Form
    {
        public BaseDialog()
        {
            Controller.ConfigData.ThemeChanged += ConfigData_ThemeChanged;
            Icon = Properties.Resources.lightning;

            // Sets the form surface colours immediately (constructor is fine for this).
            // Child controls do NOT exist yet — ApplyTheme is a no-op here, which is
            // intentional. OnLoad re-runs UpdateTheme once all controls are ready.
            UpdateTheme();
        }

        // Re-apply after InitializeComponent() in the derived form has created
        // all child controls — this is the call that actually themes them.
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
                return;
            }

            BackColor = Themes.BackColor;
            ForeColor = Themes.ForeColor;
            ApplyTheme(Controls);
        }

        /// <summary>
        /// Recursively colours every child control that does not manage its own theme.
        /// Controls that self-theme (AButton) or that need special treatment
        /// (ProgressBar, DataGridView) are skipped here.
        /// </summary>
        private void ApplyTheme(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                // AButton handles flat-style + colours itself via OnCreateControl.
                // ProgressBar: OS-drawn, colouring has no effect with visual styles.
                // DataGridView: themed individually in SchedulerDialog.ChangeTheme().
                if (ctrl is AButton || ctrl is ProgressBar || ctrl is DataGridView)
                    continue;

                ctrl.ForeColor = Themes.ForeColor;

                if (ctrl is TextBox || ctrl is ComboBox || ctrl is NumericUpDown)
                {
                    // Input fields use a dedicated colour so they stand out from
                    // the form surface — important in dark mode.
                    ctrl.BackColor = Themes.InputBackColor;
                }
                else if (ctrl is Button)
                {
                    ctrl.BackColor = Themes.BackColor;
                }

                if (ctrl is CheckBox cb)
                {
                    // UseVisualStyleBackColor = true causes Windows to ignore our
                    // BackColor entirely and paint with the system theme.
                    cb.UseVisualStyleBackColor = false;
                    cb.BackColor = Themes.BackColor;
                }

                // Recurse into any container controls (GroupBox, Panel, etc.)
                if (ctrl.Controls.Count > 0)
                    ApplyTheme(ctrl.Controls);
            }
        }
    }
}
