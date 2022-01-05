using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ImNotAfkApp
{
    public class KeepAliveLogic
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);


        private Timer m_timer = null;
        private DateTime m_endDateTime;
        private static int tickInterval = 60000;


        public event EventHandler<ElapsedEventArgs> Elapsed;
        public event EventHandler Stoped;
        public event EventHandler Started;

        public KeepAliveLogic()
        {
            State = PROGRAM_STATE.Idle;
        }

        public PROGRAM_STATE State { get; set; }

        Timer Timer
        {
            get
            {
                if (m_timer == null)
                {
                    m_timer = new Timer()
                    {
                        Interval = tickInterval
                    };
                    m_timer.Elapsed += Timer_Elapsed;

                }

                return m_timer;
            }
        }

        public bool IsAlive => m_endDateTime > DateTime.Now;


        internal void Start(int runTime)
        {
            m_endDateTime = DateTime.Now.AddMilliseconds(runTime * tickInterval);
            Timer.Start();
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
            State = PROGRAM_STATE.Running;

            Started?.Invoke(this, EventArgs.Empty);
        }

        internal void Stop()
        {
            Timer.Stop();
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
            State = PROGRAM_STATE.Idle;

            Stoped?.Invoke(this, EventArgs.Empty);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (IsAlive == false)
            {
                Stop();
                return;
            }

            Elapsed?.Invoke(sender, e);
        }

    }
}
