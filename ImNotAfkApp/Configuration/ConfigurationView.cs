using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImNotAfkApp.Configuration
{
    public partial class ConfigurationView : Form
    {
        public ConfigurationView(ConfigData configData, string text)
        {
            InitializeComponent();
            Text = text;

            ConfigData = configData;
        }

        public ConfigData ConfigData { get; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cbThemeSelect.Items.Clear();
            foreach (THEMEMODE_STATE item in Enum.GetValues(typeof(THEMEMODE_STATE)))
            {
                cbThemeSelect.Items.Add(item.GetEnumDescription());
            }

            tbInterVal.Text = ConfigData.Interval.ToString();
            cbThemeSelect.Text = ConfigData.ThemeMode.GetEnumDescription();
            cbRunOnStart.Checked = ConfigData.RunOnStartUp;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAmend_Click(object sender, EventArgs e)
        {
            ConfigData.RunOnStartUp = cbRunOnStart.Checked;
            int.TryParse(tbInterVal.Text, out int interval);
            ConfigData.Interval = interval;

            ConfigData.Save();
            Close();
        }
    }
}
