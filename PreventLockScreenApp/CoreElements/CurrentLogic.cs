using PreventLockScreen.CoreElements.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PreventLockScreen.CoreElements
{
    public class CurrentLogic
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        private Timer m_timer = null;
        private Timer m_schedulerTimer = null;
        private DateTime m_endDateTime;
        private DateTime m_startDateTime;
        private PROGRAM_STATE state;

        public event EventHandler<ElapsedEventArgs> Elapsed;

        internal void SwitchState(int interval)
        {
            if (state == PROGRAM_STATE.Running)
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
                if (state != value)
                {
                    state = value;
                    StateChanged?.Invoke(this, new StateChangedEventArgs(state));
                }
            }
        }

        public int RunningTicks
        {
            get
            {
                if (m_startDateTime > DateTime.Now) return 0;
                return (int)Math.Ceiling(DateTime.Now.Subtract(m_startDateTime).TotalMilliseconds);
            }
        }

        public int TotalTickInterval
        {
            get
            {
                if (m_startDateTime > m_endDateTime) return 0;
                return (int)Math.Ceiling(m_endDateTime.Subtract(m_startDateTime).TotalMilliseconds);
            }
        }
        public DateTime EndDateTime => m_endDateTime;

        Timer SchedulerTimer
        {
            get
            {
                if (m_schedulerTimer == null)
                {
                    m_schedulerTimer = new Timer()
                    {
                        Interval = 1000
                    };

                    m_schedulerTimer.Elapsed += SchedulerTimer_Elapsed;
                }
                return m_schedulerTimer;
            }
        }

        Timer MainTimer
        {
            get
            {
                if (m_timer == null)
                {
                    m_timer = new Timer()
                    {
                        Interval = 30000
                    };
                    m_timer.Elapsed += MainTimer_Elapsed;

                }
                return m_timer;
            }
        }

        internal void Start(int runTime) =>
            Start(runTime, null);
        internal void Start(int runTime, SchedulerItem scheduler)
        {
            if (State == PROGRAM_STATE.Idle)
            {
                m_startDateTime = DateTime.Now;
                m_endDateTime = DateTime.Now.AddMinutes(runTime);
                SchedulerTimer.Stop();
                MainTimer.Start();
                SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
                State = PROGRAM_STATE.Running;

                Notifications.Show(scheduler != null ? $"Scheduler <{scheduler.Title}> {Controller.ScreenName}" : Controller.ScreenName,
                    $"Windows is prevented from locking down{Environment.NewLine}End time is set to: {m_endDateTime.ToShortDateString()} {m_endDateTime.ToString("HH:mm")}");
                Started?.Invoke(this, EventArgs.Empty);
            }
        }
        internal void Stop()
        {
            if (State != PROGRAM_STATE.Idle)
            {
                m_endDateTime = DateTime.Now;
                MainTimer.Stop();
                SchedulerTimer.Start();
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
                State = PROGRAM_STATE.Idle;

                Notifications.Show(Controller.ScreenName,
                    $"Have ended after: {(int)DateTime.Now.Subtract(m_startDateTime).TotalMinutes} Minutes");

                Stoped?.Invoke(this, EventArgs.Empty);
            }
        }

        private void MainTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Elapsed?.Invoke(sender, e);

            if (m_endDateTime <= DateTime.Now)
            {
                Stop();
                return;
            }
        }

        internal void StartScheduler()
        {
            SchedulerTimer.Start();
        }

        private void SchedulerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (State == PROGRAM_STATE.Idle)
            {
                SchedulerTimer.Stop();

                var scheduler = Controller.Schedulers.GetSchedule(DateTime.Now.Hour);
                if (scheduler != null)
                {
                    var end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, scheduler.End, 0, 0);

                    TimeSpan span = end.Subtract(DateTime.Now);
                    if (span.TotalMinutes >= 1)
                    {
                        Start((int)Math.Ceiling(span.TotalMinutes), scheduler);
                        scheduler.Canceled = true;
                    }
                }

                SchedulerTimer.Start();
            }
        }
    }
}
