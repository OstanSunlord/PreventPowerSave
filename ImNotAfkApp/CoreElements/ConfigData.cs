﻿using ImNotAfkApp.CoreElements.State;
using System;
using System.IO;
using System.Xml.Serialization;

namespace ImNotAfkApp.CoreElements
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
        public event EventHandler<EventArgs> Loaded;
        public event EventHandler<EventArgs> RunOnStartUpChanged;

        public void Save()
        {
            XmlSerializer xs = new XmlSerializer(typeof(ConfigData));
            using (TextWriter tw = new StreamWriter(GetConfigFilePath()))
            {
                xs.Serialize(tw, this);
            }

            Saved?.Invoke(this, EventArgs.Empty);
        }

        public void Load()
        {
            if (!File.Exists(GetConfigFilePath())) return;

            ConfigData data;

            XmlSerializer ser = new XmlSerializer(typeof(ConfigData));
            using (var sr = new StreamReader(GetConfigFilePath()))
            {
                data = (ConfigData)ser.Deserialize(sr);
            }
            Interval = data.Interval;
            ThemeMode = data.ThemeMode;
            RunOnStartUp = data.RunOnStartUp;

            Loaded?.Invoke(this, EventArgs.Empty);
        }

        internal void SetRunOnStartUp(bool runOnStartUp)
        {
            if(RunOnStartUp != runOnStartUp)
            {
                RunOnStartUp = runOnStartUp;
                RunOnStartUpChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        internal void SetThemeMode(string themeMode)
        {
            ThemeMode = GetEnumValueByDescription(themeMode);
        }

        internal void SetInterval(string interVal)
        {
            if (int.TryParse(interVal, out int value))
            {
                Interval = value;
            }
        }

        private string GetConfigFilePath()
        {
            return Path.Combine(Folder.GetWorkingFolder(), "ConfigData.xml");
        }

        private THEMEMODE_STATE GetEnumValueByDescription(string description)
        {
            foreach (THEMEMODE_STATE item in Enum.GetValues(typeof(THEMEMODE_STATE)))
            {
                if (item.GetEnumDescription() == description)
                {
                    return item;
                }
            }

            return THEMEMODE_STATE.LightMode;
        }
    }
}