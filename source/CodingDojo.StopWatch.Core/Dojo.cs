using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CodingDojo.StopWatch
{
    public class Dojo : INotifyPropertyChanged
    {
        private readonly IList<Coder> coders = new List<Coder>();
        private readonly DojoTime roundTime = new DojoTime();
        private readonly DojoStopWatch stopWatch = new DojoStopWatch();
       
        private IDojoTime currentTime;
        private DojoUpdatingTimer timer;

        public event PropertyChangedEventHandler PropertyChanged;

        public Dojo()
        {
            roundTime.TimeChanged += (sender, args) => UpdateCurrentTime();
            stopWatch.TimeChanged += (sender, args) => UpdateCurrentTime();
            currentTime = roundTime;
            timer = new DojoUpdatingTimer(stopWatch, 1000.0);
        }

        private void UpdateCurrentTime()
        {
            OnPropertyChanged("CurrentTime");
        }

        public void AddCoder(Coder coder)
        {
            coders.Add(coder);
            OnPropertyChanged("CodersCount");
        }

        public int CodersCount
        {
            get { return coders.Count; }
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public TimeSpan CurrentTime
        {
            get { return currentTime.Time; }
        }

        public void IncreaseTime()
        {
            currentTime.Increase();
        }

        public void SetRoundTime(TimeSpan timeSpan)
        {
            roundTime.SetTime(timeSpan);
        }

        public void DecreaseTime()
        {
            currentTime.Decrease();
        }

        public void StartNewRound()
        {
            currentTime = stopWatch;
            stopWatch.StartRound(roundTime);
            timer.Start();
            UpdateCurrentTime();
        }
    }
}