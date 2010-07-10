using System;
using System.ComponentModel;

namespace CodingDojo.StopWatch
{
    public class Coder : INotifyPropertyChanged
    {
        private string name;

        public Coder() : this(string.Empty)
        {
        }

        public Coder(string coderName)
        {
            name = coderName;
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}