using System;
using System.Windows.Input;
using CodingDojo.StopWatch.Controls.Commands;

namespace CodingDojo.StopWatch.Controls
{
    public class DojoViewModel : Dojo
    {
        private ICommand upOneMinuteCommand;
        private ICommand downOneMinuteCommand;
        private ICommand startDojo;
        private ICommand pushbackFirst;

        public DojoViewModel()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            upOneMinuteCommand = new ActionCommand(() => IncreaseTime());
            downOneMinuteCommand = new ActionCommand(() => DecreaseTime());
            startDojo = new ActionCommand(()=>StartNewRound());
            pushbackFirst = new ActionCommand<Coder>((parameter) => 
PushbackTeamMember(parameter)
);
        }

        public ICommand StartDojo
        {
            get { return startDojo; }

        }

        public ICommand MinutesUp
        {
            get { return upOneMinuteCommand; }
        }
        

        public ICommand MinutesDown
        {
            get { return downOneMinuteCommand; }
        }
        public ICommand PushbackMember
        {
            get { return pushbackFirst ; }
        }
    }

}