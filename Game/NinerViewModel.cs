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

        public NinerViewModel(NinerId id, ICreateCells cellFactory)
        {
            _id = id;
            _cells = new[] { 0, 1, 2 }.ToList().Select(row =>
                    new[] { 0, 1, 2 }.ToList().Select(column =>
                        cellFactory.Create(_id, column, row)));
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

        
    }
}