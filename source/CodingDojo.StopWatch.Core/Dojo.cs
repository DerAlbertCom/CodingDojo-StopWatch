using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CodingDojo.StopWatch
{
    public class Dojo : INotifyPropertyChanged
    {
        private readonly IList<Coder> coders = new List<Coder>();
        private readonly DojoTime roundTime = new DojoTime();
        private readonly DojoStopWatch stopWatch = new DojoStopWatch();
        private readonly DojoTeam dojoTeam = new DojoTeam();

        private IDojoTime currentTime;
        private readonly DojoUpdatingTimer timer;

        public event PropertyChangedEventHandler PropertyChanged;

        public Dojo()
        {
            roundTime.SetTime(new TimeSpan(0, 8, 0));
            roundTime.TimeChanged += (sender, args) => UpdateCurrentTime();
            stopWatch.TimeChanged += (sender, args) => UpdateCurrentTime();
            dojoTeam.PropertyChanged += (sender, args) => UpdateTeamMembers();
            currentTime = roundTime;
            timer = new DojoUpdatingTimer(stopWatch, 1000.0);

            dojoTeam.Queue.Enqueue(new Coder("Albert Weinert"));
            dojoTeam.Queue.Enqueue(new Coder("Ilker Cetinkaya"));
            dojoTeam.Queue.Enqueue(new Coder("Bernd Hengelein"));
            dojoTeam.GetNextTeamMembers();
        }

        private void UpdateCurrentTime()
        {
            OnPropertyChanged("CurrentTime");
        }

        private void UpdateTeamMembers()
        {
            OnPropertyChanged("CurrentTeamMembers");
        }


        public void AddCoder(string codername)
        {
            coders.Add(new Coder() {Name = codername});
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

        public  string CurrentTime
        {
            get { return currentTime.ToString(); }
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

        public void PushbackTeamMember(int index)
        {
            dojoTeam.PushbackTeamMember(index);
        }
        public void StartNewRound()
        {
            currentTime = stopWatch;
            dojoTeam.GetNextTeamMembers();
            stopWatch.StartRound(roundTime);
            timer.Start();
            UpdateCurrentTime();
        }

        public DojoTeam DojoTeam
        {
            get { return dojoTeam; }
        }

        public IEnumerable<Coder> Coders
        {
            get { return coders; }
        }


        public Coder[] CurrentTeamMembers
        {
            get { return dojoTeam.CurrentTeamMembers.ToArray(); }
        }
    }
}