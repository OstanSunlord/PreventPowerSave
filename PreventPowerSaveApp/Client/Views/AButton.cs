using PreventPowerSave.CoreElements;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PreventPowerSave.Client
{
    public partial class AButton : Button
    {
        public AButton()
        {
            InitializeComponent();

        }

        public AButton(IContainer container)
        {
            container.Add(this);
            
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            FlatStyle = FlatStyle.Flat;
            SetTheme();
            Controller.ConfigData.ThemeChanged += ConfigData_ThemeChanged;
        }

        private void SetTheme()
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate { SetTheme(); });
            }
            else
            {
                UseVisualStyleBackColor = false;
                ForeColor = Themes.ForeColor;
                BackColor = Themes.BackColor;
                FlatAppearance.BorderColor = Themes.BorderColor;
                FlatAppearance.MouseOverBackColor = Themes.HoverColor;
            }
        }

        private void ConfigData_ThemeChanged(object sender, System.EventArgs e)
        {
            SetTheme();
        }

    }
}
