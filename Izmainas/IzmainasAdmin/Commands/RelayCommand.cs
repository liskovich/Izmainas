using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace IzmainasAdmin.Commands
{
    public class RelayCommand : ICommand
    {
        Action<object> _executemethod;
        Func<object, bool> _canexecutemethod;

        public RelayCommand(Action<object> executemethod, Func<object, bool> canexecutemethod)
        {
            _executemethod = executemethod;
            _canexecutemethod = canexecutemethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_executemethod != null)
            {
                return _canexecutemethod(parameter);
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            _executemethod(parameter);
        }
    }
}
