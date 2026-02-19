using PreventPowerSave.CoreElements.State;
using System;
using System.IO;
using System.Xml.Serialization;

namespace PreventPowerSave.CoreElements
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
        [XmlAttribute("tray")]
        public bool RunInSystemTray { get; set; } = true;
        [XmlAttribute("scheduler")]
        public string Scheduler { get; set; } = string.Empty;
        [XmlAttribute("endlessMode")]
        public bool EndlessMode { get; set; } = false;
        [XmlAttribute("afkPrevention")]
        public bool AfkPreventionEnabled { get; set; } = false;

        public event EventHandler<EventArgs> Saved;
        public event EventHandler<EventArgs> Loaded;
        public event EventHandler<EventArgs> RunOnStartUpChanged;
        public event EventHandler<EventArgs> RunInSystemTrayChanged;

        public event EventHandler<EventArgs> ThemeChanged;
        public event EventHandler<EventArgs> SchedulerChanged;


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
            RunInSystemTray = data.RunInSystemTray;
            Scheduler = data.Scheduler;
            EndlessMode = data.EndlessMode;
            AfkPreventionEnabled = data.AfkPreventionEnabled;
            Controller.Schedulers.Load(Scheduler);

            Loaded?.Invoke(this, EventArgs.Empty);
        }

        internal void SetRunInSystemTray(bool state)
        {
            if(RunInSystemTray != state)
            {
                RunInSystemTray = state;
                RunInSystemTrayChanged?.Invoke(this, EventArgs.Empty);
            }
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
            var theme = GetEnumValueByDescription(themeMode);
            if (ThemeMode != theme)
            {
                ThemeMode = theme;
                ThemeChanged.Invoke(this, EventArgs.Empty);
            }
        }

        internal void SetScheduler(string scheduler)
        {
            if(Scheduler != scheduler)
            {
                Scheduler = scheduler;
                SchedulerChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        internal void SetInterval(string interVal)
        {
            if (int.TryParse(interVal, out int value))
            {
                Interval = value;
            }
        }

        internal void SetEndlessMode(bool value) => EndlessMode = value;

        internal void SetAfkPreventionEnabled(bool value) => AfkPreventionEnabled = value;

        private string GetConfigFilePath()
        {
            return Path.Combine(Folder.GetWorkingFolder(), "Config.xml");
        }

        internal THEMEMODE_STATE GetEnumValueByDescription(string description)
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
