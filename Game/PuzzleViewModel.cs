using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;

namespace Sudoque.Game
{
    public class PuzzleViewModel
    {
        private readonly ICreateNiners _ninerFactory;
        private readonly NumberCommand _numberPressCommand;

        public PuzzleViewModel(ICreateNiners ninerFactory, IEventAggregator events)
        {
            _ninerFactory = ninerFactory;
            _numberPressCommand = new NumberCommand(events.GetEvent<NumberPressEvent>());
        }

        public IEnumerable<IEnumerable<NinerViewModel>> Niners
        {
            get
            {
               return new[]{0, 1, 2}.ToList().Select(row => 
                   new[]{0, 1, 2}.ToList().Select(column => 
                       _ninerFactory.Create(column, row)));
            }
        }

        public ICommand NumberPress
        {
            get { return _numberPressCommand; }
        }

        private class NumberCommand : ICommand
        {
            private readonly NumberPressEvent _numberPressEvent;

            internal NumberCommand(NumberPressEvent numberPressEvent)
            {
                _numberPressEvent = numberPressEvent;
            }

            public void Execute(object parameter)
            {
                int payload = int.Parse(parameter.ToString());
                _numberPressEvent.Publish(payload);
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;
        }
    }
}