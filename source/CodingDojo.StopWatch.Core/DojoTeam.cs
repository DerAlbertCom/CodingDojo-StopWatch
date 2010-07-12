using System;
using System.ComponentModel;

namespace CodingDojo.StopWatch
{
    public class DojoTeam : INotifyPropertyChanged
    {
        private const int TeamSize = 2;

        public DojoTeam()
        {
            CurrentTeamMembers = new SimpleArray<Coder>(TeamSize);
            Queue = new CoderQueue();
        }

        public void GetNextTeamMembers()
        {
            MoveTeamMemberUp();
            if (CurrentTeamMembers[0] == null)
            {
                MoveTeamMemberUp();
            }   
            OnPropertyChanged("CurrentTeamMembers");
        }

        private void MoveTeamMemberUp()
        {
            CurrentTeamMembers[0] = CurrentTeamMembers[1];
            CurrentTeamMembers[1] = Queue.DequeueAndEnqueue();
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SimpleArray<Coder> CurrentTeamMembers { get; private set; }

        public CoderQueue Queue { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void PushbackTeamMember(int teamMember)
        {
            if (teamMember==0)
            {
                var coder = CurrentTeamMembers[0];
                MoveTeamMemberUp();
                Queue.Push(coder);
                OnPropertyChanged("CurrentTeamMembers");
            } else
            {
                var coder = CurrentTeamMembers[1];
                CurrentTeamMembers[1] = Queue.DequeueAndEnqueue();
                Queue.Push(coder);
                OnPropertyChanged("CurrentTeamMembers");
            }
        }

        public Coder LookNextTeamMember()
        {
            return Queue.Peek();
        }
    }
}