using System;
using System.Windows.Input;

namespace CodingDojo.StopWatch.Controls.Commands
{
    public class ActionCommand : ICommand
    {
        private Action action;

        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action();
        }
    }

    public class ActionCommand<T> : ICommand
    {
        private Action<T> action;

        public ActionCommand(Action<T> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action((T)parameter);
        }
    }

}