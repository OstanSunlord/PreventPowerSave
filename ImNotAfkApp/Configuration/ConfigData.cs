using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImNotAfkApp.Configuration
{
    public class ConfigData
    {
        public ConfigData() { }

        [XmlAttribute("interval")]
        public int Interval { get; set; } = 120;
        [XmlAttribute("startup")]
        public bool RunOnStartUp { get; set; } = false;
        [XmlAttribute("theme")]
        public THEMEMODE_STATE ThemeMode { get; set; } = THEMEMODE_STATE.LightMode;

        public event EventHandler<EventArgs> Saved;


        public void Save() 
        {
            XmlSerializer xs = new XmlSerializer(typeof(ConfigData));
            using (TextWriter tw = new StreamWriter(GetConfigFilePath()))
            {
                xs.Serialize(tw, this);
            }

            Saved?.Invoke(this, EventArgs.Empty);
        }

        public ConfigData Load()
        {
            if (!File.Exists(GetConfigFilePath())) return new ConfigData();

            XmlSerializer ser = new XmlSerializer(typeof(ConfigData));
            using (var sr = new StreamReader(GetConfigFilePath()))
            {
                return (ConfigData)ser.Deserialize(sr);
            }
        }

        private string GetConfigFilePath()
        {
            return Path.Combine(Folder.GetWorkingFolder(), "ConfigData.xml");
        }
    }
}
