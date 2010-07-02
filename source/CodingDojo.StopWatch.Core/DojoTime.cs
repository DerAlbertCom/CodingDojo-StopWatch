using System;

namespace CodingDojo.StopWatch
{
    public class DojoTime : IDojoTime
    {
        private TimeSpan time = new TimeSpan(0);
        private static readonly TimeSpan OneMinute = new TimeSpan(0, 1, 0);

        public event EventHandler TimeChanged;

        public TimeSpan Time
        {
            get { return time; }
            private set
            {
                if (time != value)
                {
                    time = value;
                    OnTimeChanged();
                }
            }
        }

        private void OnTimeChanged()
        {
            var handler = TimeChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Increase()
        {
            Time = Time.Add(OneMinute);
        }

        public void SetTime(TimeSpan timeSpan)
        {
            Time = timeSpan;
        }

        public void Decrease()
        {
            Time = Time.Subtract(OneMinute);
        }
    }
}