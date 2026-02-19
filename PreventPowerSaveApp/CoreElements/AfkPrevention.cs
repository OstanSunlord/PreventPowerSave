using System.Runtime.InteropServices;
using System.Timers;

namespace PreventPowerSave.CoreElements
{
    public static class AfkPrevention
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            [FieldOffset(0)] public int type;
            [FieldOffset(4)] public int dx;
            [FieldOffset(8)] public int dy;
            [FieldOffset(12)] public uint mouseData;
            [FieldOffset(16)] public uint dwFlags;
            [FieldOffset(20)] public uint time;
            [FieldOffset(24)] public System.IntPtr dwExtraInfo;

            public static int Size => Marshal.SizeOf(typeof(INPUT));
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        private const int INPUT_MOUSE = 0;
        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const uint IdleThresholdMs = 270000; // 4.5 minutes — fires before Teams' 5-min away mark
        private const double CheckIntervalMs = 30000; // check every 30 seconds

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        private static Timer _timer;

        public static void Start()
        {
            if (_timer == null)
            {
                _timer = new Timer { Interval = CheckIntervalMs };
                _timer.Elapsed += Timer_Elapsed;
            }
            _timer.Start();
        }

        public static void Stop()
        {
            _timer?.Stop();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (GetIdleTimeMs() >= IdleThresholdMs)
                JiggleMouse();
        }

        private static uint GetIdleTimeMs()
        {
            var info = new LASTINPUTINFO { cbSize = (uint)Marshal.SizeOf(typeof(LASTINPUTINFO)) };
            if (!GetLastInputInfo(ref info)) return 0;
            return (uint)System.Environment.TickCount - info.dwTime;
        }

        private static void JiggleMouse()
        {
            var inputs = new INPUT[]
            {
                new INPUT { type = INPUT_MOUSE, dx = 1,  dy = 0, dwFlags = MOUSEEVENTF_MOVE },
                new INPUT { type = INPUT_MOUSE, dx = -1, dy = 0, dwFlags = MOUSEEVENTF_MOVE },
            };
            SendInput((uint)inputs.Length, inputs, INPUT.Size);
        }
    }
}
