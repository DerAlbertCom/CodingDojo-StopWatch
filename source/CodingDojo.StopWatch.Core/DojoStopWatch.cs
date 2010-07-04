using System;

namespace CodingDojo.StopWatch
{
    public class DojoStopWatch : IDojoTime
    {
        private static readonly TimeSpan OneMinute = new TimeSpan(0, 1, 0);
        private static readonly TimeSpan ZeroMinutes = new TimeSpan(0, 0, 0);
        private DateTime currentTime;

        private DateTime endTime;

        public event EventHandler TimeChanged;

        public TimeSpan Time
        {
            get
            {
                if (currentTime > endTime)
                    return ZeroMinutes;
                var tmp = endTime - currentTime;
                return new TimeSpan(tmp.Hours, tmp.Minutes, tmp.Seconds);
            }
        }

        public void Increase()
        {
            endTime = endTime.Add(OneMinute);
            OnTimeChanged();
        }

        public void Decrease()
        {
            endTime = endTime.Subtract(OneMinute);
            OnTimeChanged();
        }

        public void StartRound(IDojoTime dojoTime)
        {
            currentTime = DateTime.Now;
            endTime = currentTime.Add(dojoTime.Time);
            OnTimeChanged();
        }

        private void OnTimeChanged()
        {
            var handler = TimeChanged;
            if (handler!=null)
            {
                handler(this,EventArgs.Empty);
            }
        }
    }
}