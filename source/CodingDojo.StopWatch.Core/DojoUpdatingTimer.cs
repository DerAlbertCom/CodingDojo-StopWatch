using System.Timers;

namespace CodingDojo.StopWatch
{
    public class DojoUpdatingTimer
    {
        private readonly IUpdating updating;
        private readonly Timer timer = new Timer();

        public DojoUpdatingTimer(IUpdating updating, double interval)
        {
            this.updating = updating;
            timer.Interval = interval;
            timer.Enabled = false;
            timer.AutoReset = true;
            timer.Elapsed += Update;
        }

        private void Update(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            updating.Update();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}