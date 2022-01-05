using ImNotAfkApp.Client.Configuration;

namespace ImNotAfkApp.CoreElements
{
    public static class Controller
    {
        public static ConfigData ConfigData { get; set; } = new ConfigData();
        public static ConfigurationDialog ConfigurationDialog { get; set; } = null;
        public static CurrentLogic CurrentLogic { get; } = new CurrentLogic();

    }
}
