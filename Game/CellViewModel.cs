using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.Prism.Events;

namespace Sudoque.Game
{
    public class CellViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        private readonly CellId _id;
        private readonly CellSelectedEvent _selectionEvent;
        private bool _selected;
        private readonly NumberPressEvent _numberPressEvent;
        private readonly HashSet<int> _potentials;

        public CellViewModel(CellId id, IEventAggregator events)
        {
            _id = id;
            _potentials = new HashSet<int>();
            _selectionEvent = events.GetEvent<CellSelectedEvent>();
            _selectionEvent.Subscribe(cellId =>
                                  {
                                      if (!_id.Equals(cellId))
                                      {
                                          Selected = false;
                                      }
                                  });
            _numberPressEvent = events.GetEvent<NumberPressEvent>();
            _numberPressEvent.Subscribe(number =>
                                            {
                                                if (!Selected) return;
                                                if (!_potentials.Remove(number)) {_potentials.Add(number);}
                                                PropertyChanged(this, new PropertyChangedEventArgs("Potentials"));
                                                PropertyChanged(this, new PropertyChangedEventArgs("Actual"));
                                            });
        }

        public string Potentials
        {
            get
            {
                if (_potentials.Count < 2)
                {
                    return string.Empty;
                }
                var orderedPotentials = _potentials.ToList();
                orderedPotentials.Sort();
                return string.Join(" ", orderedPotentials);
            }
        }

        public string Actual
        {
            get 
            {
                if (_potentials.Count != 1)
                {
                    return string.Empty;
                }
                return _potentials.First().ToString();
            }
        }

        public bool Selected { 
             get { return _selected; }
             set
             {
                 if (_selected != value)
                 {
                     _selected = value;
                     if (value) { _selectionEvent.Publish(_id); }
                     PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
                 }
             } 
        }

        
    }
}