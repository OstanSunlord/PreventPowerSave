using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImNotAfkApp.CoreElements
{
    public static class Folder
    {
        public static string GetWorkingFolder()
        {
            var parh = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ImNotAfkApp");

            if(!Directory.Exists(parh))
            {
                Directory.CreateDirectory(parh);
            }
            return parh;
        }

    }
}
