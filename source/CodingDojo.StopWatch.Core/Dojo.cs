using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CodingDojo.StopWatch
{
    public class Dojo : INotifyPropertyChanged
    {
        private readonly IList<Coder> coders = new List<Coder>();
        private readonly DojoTime teamDojoTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public Dojo()
        {
            teamDojoTime = new DojoTime();
            teamDojoTime.TimeChanged+=TeamDojoTimeOnTimeChanged;
               
        }

        private void TeamDojoTimeOnTimeChanged(object sender, EventArgs eventArgs)
        {
            OnPropertyChanged("TeamTime");
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

        public TimeSpan TeamTime
        {
            get { return teamDojoTime.Time; }
        }

        public void IncreaseTeamTime()
        {
            teamDojoTime.Increase();
        }

        public void SetTeamTime(TimeSpan timeSpan)
        {
            teamDojoTime.SetTime(timeSpan);
        }


        public void DecreaseTeamTime()
        {
            teamDojoTime.Decrease();
        }
    }
}