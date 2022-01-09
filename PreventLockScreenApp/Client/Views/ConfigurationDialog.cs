using PreventLockScreen.CoreElements;
using PreventLockScreen.CoreElements.State;
using System;
using System.Windows.Forms;

namespace PreventLockScreen.Client
{
    public partial class ConfigurationDialog : BaseDialog
    {
        public ConfigurationDialog(ConfigData configData, string text)
        {
            InitializeComponent();
            Text = text;

            ConfigData = configData;

            btnAmend.BackColor = BackColor;
            btnClose.BackColor = BackColor;
        }

        public ConfigData ConfigData { get; }

        public string InterVal
        {
            get => tbInterVal.Text;
            set => tbInterVal.Text = value;
        }
        public string ThemeMode
        {
            get => cbThemeSelect.Text;
            set => cbThemeSelect.Text = value;
        }
        public bool RunOnStartUp
        {
            get => cbRunOnStart.Checked;
            set => cbRunOnStart.Checked = value;
        }

        public bool RunInSystemTray
        {
            get => cbRunAsSystemTray.Checked;
            set => cbRunAsSystemTray.Checked = value;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cbThemeSelect.Items.Clear();
            foreach (THEMEMODE_STATE item in Enum.GetValues(typeof(THEMEMODE_STATE)))
            {
                cbThemeSelect.Items.Add(item.GetEnumDescription());
            }

            InterVal = ConfigData.Interval.ToString();
            ThemeMode = ConfigData.ThemeMode.GetEnumDescription();
            RunOnStartUp = ConfigData.RunOnStartUp;
            RunInSystemTray = ConfigData.RunInSystemTray;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                DialogResult = button.DialogResult;
                Close();
            }
        }
    }
}
