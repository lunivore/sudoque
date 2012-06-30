using System.ComponentModel;
using Microsoft.Practices.Prism.Events;

namespace Sudoque.Game
{
    public class CellViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        private readonly CellId _id;
        private readonly CellSelectedEvent _selectionEvent;
        private bool _selected;

        public CellViewModel(CellId id, IEventAggregator events)
        {
            _id = id;
            _selectionEvent = events.GetEvent<CellSelectedEvent>();
            _selectionEvent.Subscribe(cellId =>
                                  {
                                      if (!_id.Equals(cellId))
                                      {
                                          Selected = false;
                                      }
                                  });
        }

        public string Potentials { get { return "1 2 3 4 5 6 7 8"; } }

        public string Actual { get { return _id.ToString(); } }

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