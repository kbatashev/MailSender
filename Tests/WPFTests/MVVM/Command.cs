using System;
using System.Windows.Input;

namespace MailSender.MVVM
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> _action;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _action?.Invoke(parameter);

        public Command(Action<object> action) => _action = action;
    }
}
