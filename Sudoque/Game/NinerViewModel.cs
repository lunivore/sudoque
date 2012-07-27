using System.Collections.Generic;
using System.Linq;

namespace Sudoque.Game
{
    public class NinerViewModel
    {
        private readonly IEnumerable<CellViewModel> _cells;
        private int _id;

        public NinerViewModel(int id, ICreateCellViewModels cellViewModelFactory)
        {
            _id = id;

            var cellModels = new List<CellViewModel>();

            foreach (var cellId in Enumerable.Range(0, 9))
            {
                cellModels.Add(cellViewModelFactory.Create(id, cellId));
            }
            _cells = cellModels;
        }

        public IEnumerable<CellViewModel> Cells
        {
            get { return _cells; }
        }

        public override string ToString()
        {
            return string.Format("NinerViewModel[{0}]", _id);
        }
    }
}