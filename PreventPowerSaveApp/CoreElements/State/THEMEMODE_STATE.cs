using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreventPowerSave.CoreElements.State
{
    [FlagsAttribute]
    public enum THEMEMODE_STATE
    {
        [Description("Light Theme")]
        LightMode = 0,
        [Description("Dark Theme")]
        DarkMode = 1
    }
}
