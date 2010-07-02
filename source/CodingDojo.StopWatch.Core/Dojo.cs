using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CodingDojo.StopWatch
{
    public class Dojo : INotifyPropertyChanged
    {
        private readonly IList<Coder> coders = new List<Coder>();
        private readonly DojoTime teamDojoTime = new DojoTime();
        private DojoStopWatch stopWatch;

        private IDojoTime currentTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public Dojo()
        {
            teamDojoTime.TimeChanged += (sender, args) => OnPropertyChanged("TeamTime");
            currentTime = teamDojoTime;
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

        public void SetTeamTime(TimeSpan timeSpan)
        {
            teamDojoTime.SetTime(timeSpan);
        }

        public void DecreaseTime()
        {
            currentTime.Decrease();
        }

        public void StartNewRound()
        {
            stopWatch = new DojoStopWatch();
            currentTime = stopWatch;
            stopWatch.StartRound(teamDojoTime);
        }
    }
}