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
        private IEnumerable<IEnumerable<CellViewModel>> _cells;

        public NinerViewModel(NinerId id, ICreateCellViewModels cellViewModelFactory)
        {
            _id = id;

            var range = new[] { 0, 1, 2 }.ToList();
            var tempCells = new List<List<CellViewModel>>();
            foreach (var row in range)
            {
                tempCells.Add(new List<CellViewModel>());
                foreach (var col in range)
                {
                    tempCells[row].Add(cellViewModelFactory.Create(id, col, row));
                }
            }
            _cells = tempCells;
        }

        public IEnumerable<IEnumerable<CellViewModel>> Cells
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