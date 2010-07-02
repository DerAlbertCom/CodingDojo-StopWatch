using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CodingDojo.StopWatch
{
    public class Dojo : INotifyPropertyChanged
    {
        private readonly IList<Coder> coders = new List<Coder>();

        public Dojo()
        {
            TeamTime = new TimeSpan(0, 0, 0);
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

        private TimeSpan teamTime;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public TimeSpan TeamTime
        {
            get { return teamTime; }
            private set
            {
                if (teamTime != value)
                {
                    teamTime = value;
                    OnPropertyChanged("TeamTime");
                }
            }
        }

        public void IncreaseTeamTime()
        {
            TeamTime = TeamTime.Add(new TimeSpan(0, 1, 0));
        }

        public void SetTeamTime(TimeSpan timeSpan)
        {
            TeamTime = timeSpan;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void DecreaseTeamTime()
        {
            TeamTime = TeamTime.Subtract(new TimeSpan(0, 1, 0));
        }
    }
}