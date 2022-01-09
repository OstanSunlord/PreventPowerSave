using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreventLockScreen.CoreElements.State
{
    [FlagsAttribute]
    public enum PROGRAM_STATE
    {
        Idle,
        Running
    }
}
