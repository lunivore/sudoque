using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Sudoque.Game.Engine;

namespace Sudoque.Game
{
    public class CellViewModel : ViewModel
    {
        private readonly CellSelectedEvent _selectionEvent;
        private readonly Cell _cell;
        private bool _selected;

        public CellViewModel(Cell cell, IEventAggregator events)
        {
            _cell = cell;

            GotFocus = new DelegateCommand<string>( CellFocused);

            _selectionEvent = events.GetEvent<CellSelectedEvent>();
            _selectionEvent.Subscribe( c =>
                                  {
                                      Selected = _cell == c;
                                  }); // Note: Could be memory leak due to event link

            events.GetEvent<HintProvidedEvent>().Subscribe( hint =>
                {
                    if( hint.CellIds.Contains( _cell.Id ) )
                    {
                        if (CellHinted != null) CellHinted(this, EventArgs.Empty);
                    }
                });

            var numberRequestEvent = events.GetEvent<NumberRequestEvent>();
            numberRequestEvent.Subscribe(ToggleNumber);

            var modeRequestEvent = events.GetEvent<ModeRequestEvent>();
            modeRequestEvent.Subscribe(ChangeMode);
        }

        private void ChangeMode(Mode mode)
        {
            _cell.ChangeMode(mode);
            NotifyPropertyChanged(() => Actual, () => Potentials);
            NotifyPropertyChanged(() => Fixed);
        }

        private void ToggleNumber(int number)
        {
            if (!Selected) return;
            _cell.RequestToggleNumber(number);
            NotifyPropertyChanged(() => Actual, () => Potentials);
            NotifyPropertyChanged(() => HasPotentials);
        }

        protected bool HasPotentials
        {
            get { return _cell.Potentials.Any(); }
        }

        public bool Fixed { get { return _cell.Fixed; } }

        public string Potentials
        {
            get
            {
                return string.Join(" ", _cell.Potentials);
            }
        }

        public string Actual
        {
            get { return _cell.Actual == null ? string.Empty : _cell.Actual.ToString(); }
        }

        public bool Selected { 
             get { return _selected; }
             private set
             {
                 if (_selected != value)
                 {
                     _selected = value;
                     NotifyPropertyChanged(() => Selected);
                 }
             } 
        }

        public ICommand GotFocus { get; set; }
        
        private void CellFocused( string unused )
        {
            _selectionEvent.Publish( _cell );
        }
        
        public override string ToString()
        {
            return _cell.ToString();
        }

        public Cell Cell { get { return _cell; } }

        public event EventHandler<EventArgs> CellHinted;
    }
}