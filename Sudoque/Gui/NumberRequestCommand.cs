using System;
using System.Windows.Input;
using Sudoque.Game;

namespace Sudoque.Gui
{
    public class NumberRequestCommand : ICommand
    {
        private readonly NumberRequestEvent _numberRequestEvent;

        internal NumberRequestCommand(NumberRequestEvent numberRequestEvent)
        {
            _numberRequestEvent = numberRequestEvent;
        }

        public void Execute(object parameter)
        {
            int payload = int.Parse(parameter.ToString());
            _numberRequestEvent.Publish(payload);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}