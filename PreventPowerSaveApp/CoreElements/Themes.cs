using PreventPowerSave.CoreElements;
using PreventPowerSave.CoreElements.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreventPowerSave.CoreElements
{
    public static class Themes
    {
        public static THEMEMODE_STATE Mode => Controller.ConfigData.ThemeMode;


        public static Color BackColor 
        {
            get
            {
                return Mode == THEMEMODE_STATE.DarkMode ? SystemColors.ControlDarkDark : SystemColors.Control;
            }
        }
        public static Color ForeColor
        {
            get
            {
                return Mode == THEMEMODE_STATE.DarkMode ? Color.White : Color.Black;
            }
        }

    }
}
