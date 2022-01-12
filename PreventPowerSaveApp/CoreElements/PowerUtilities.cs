using PreventPowerSave.CoreElements.State;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace PreventPowerSave.CoreElements
{
    public static class PowerUtilities
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint SetThreadExecutionState(EXECUTION_STATE esFlags);

        private static AutoResetEvent _event = new AutoResetEvent(false);

        public static void PreventPowerSave()
        {
            (new TaskFactory()).StartNew(() =>
            {
                SetThreadExecutionState(
                    EXECUTION_STATE.ES_CONTINUOUS
                    | EXECUTION_STATE.ES_DISPLAY_REQUIRED
                    | EXECUTION_STATE.ES_SYSTEM_REQUIRED);
                _event.WaitOne();

            },
                TaskCreationOptions.LongRunning);
        }

        public static void Shutdown()
        {
            _event.Set();
        }
    }
}
