using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Sudoque.Game
{
    public class NinerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly NinerId _id;
        private IEnumerable<CellViewModel> _cells;

        public NinerViewModel(NinerId id, ICreateCellViewModels cellViewModelFactory)
        {
            _id = id;

            List<CellViewModel> models = new List<CellViewModel>();

            var range = new[] { 0, 1, 2 };
            foreach (var row in range)
            foreach (var col in range)
            {
                models.Add(cellViewModelFactory.Create(id, col, row));
            }
            _cells = models;
        }

        public IEnumerable<CellViewModel> Cells
        {
            get { return _cells; }
        }

        public CellViewModel CurrentCell
        {
            get
            {
                return null;
            }
            set
            {
                value.Selected = true;
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentCell"));
            }
        }

        public override string ToString()
        {
            return _id.ToString();
        }
    }
}