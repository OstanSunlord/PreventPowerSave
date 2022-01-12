using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreventPowerSave.CoreElements
{
    public static class Folder
    {
        public static string GetWorkingFolder()
        {
            var parh = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PreventLockScreenApp");

            if(!Directory.Exists(parh))
            {
                Directory.CreateDirectory(parh);
            }
            return parh;
        }

    }
}
