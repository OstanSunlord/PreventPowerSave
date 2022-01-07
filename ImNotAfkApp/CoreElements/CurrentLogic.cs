using ImNotAfkApp.CoreElements.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ImNotAfkApp.CoreElements
{
    public class CurrentLogic
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);


        private Timer m_timer = null;
        private DateTime m_endDateTime;
        private static int tickInterval = 60000;
        private PROGRAM_STATE state;

        public event EventHandler<ElapsedEventArgs> Elapsed;

        internal void SwitchState(int interval)
        {
            if(IsAlive)
            {
                Stop();
            }
            else
            {
                Start(interval);
            }
        }

        public event EventHandler Stoped;
        public event EventHandler Started;

        public event EventHandler<StateChangedEventArgs> StateChanged;

        public CurrentLogic()
        {
            State = PROGRAM_STATE.Idle;
        }

        public PROGRAM_STATE State
        {
            get => state;
            set
            {
                if(state != value)
                {
                    state = value;
                    StateChanged?.Invoke(this, new StateChangedEventArgs(state));
                }
            }
        }

        public int TickInterval => tickInterval;
        public DateTime EndDateTime => m_endDateTime;

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
            if (State != PROGRAM_STATE.Idle)
            {
                m_endDateTime = DateTime.Now;
                Timer.Stop();
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
                State = PROGRAM_STATE.Idle;
                Stoped?.Invoke(this, EventArgs.Empty);
            }
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
