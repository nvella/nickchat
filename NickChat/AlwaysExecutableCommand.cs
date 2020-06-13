using System;
using System.Windows.Input;

namespace NickChat
{
    public class AlwaysExecutableCommand : ICommand
    {
        private Action _action;

        public AlwaysExecutableCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged = (_, __) => { };

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _action();
    }
}