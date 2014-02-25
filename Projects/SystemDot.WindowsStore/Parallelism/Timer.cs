using System;
using System.Threading.Tasks;

namespace SystemDot.Parallelism
{
    public class Timer
    {
        readonly double interval;
        ElapsedEventHandler elapsed;
        bool enabled;

        public Timer(double interval)
        {
            this.interval = interval;
        }

        public bool AutoReset { get; set; }

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                ScheduleTask();
            }
        }

        public event ElapsedEventHandler Elapsed
        {
            add { elapsed += value; }
            remove { elapsed -= value; }
        }

        void ScheduleTask()
        {
            Task.Run(async () =>
            {
                if (!enabled) return;

                await Task.Delay(TimeSpan.FromMilliseconds(interval));

                OnElapsed();
            });
        }

        void OnElapsed()
        {
            if (elapsed == null) return;
            elapsed(this, new ElapsedEventHandlerArgs());
        }
    }
}