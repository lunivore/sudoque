using System.Linq;
using Microsoft.Practices.Prism.Events;
using Sudoque.Game.Engine;

namespace Sudoque.Game
{
    public class CellViewModel : ViewModel
    {
        private readonly CellId _id;
        private readonly CellSelectedEvent _selectionEvent;
        private readonly Cell _cell;
        private bool _selected;

        public CellViewModel(CellId id, IEventAggregator events)
        {
            _id = id;
            _cell = new Cell();
            _selectionEvent = events.GetEvent<CellSelectedEvent>();
            _selectionEvent.Subscribe(cellId =>
                                  {
                                      if (!_id.Equals(cellId))
                                      {
                                          Selected = false;
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
             set
             {
                 if (_selected != value)
                 {
                     _selected = value;
                     if (value) { _selectionEvent.Publish(_id); }
                     NotifyPropertyChanged(() => Selected);
                 }
             } 
        }
    }
}