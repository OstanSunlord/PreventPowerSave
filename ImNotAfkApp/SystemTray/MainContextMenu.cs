using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImNotAfkApp.SystemTray
{
    public class MainContextMenu : ContextMenu
    {
        public MainContextMenu() : base()
        {

        }

        public MainContextMenu(MenuItem[] menuItems) : base(menuItems)
        {

        }

    }
}
