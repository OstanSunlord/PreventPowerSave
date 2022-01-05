using ImNotAfkApp.CoreElements;
using ImNotAfkApp.CoreElements.State;
using System;
using System.Windows.Forms;

namespace ImNotAfkApp.Client.Configuration
{
    public partial class ConfigurationDialog : Form
    {
        public ConfigurationDialog(ConfigData configData, string text)
        {
            InitializeComponent();
            Text = text;

            ConfigData = configData;
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
