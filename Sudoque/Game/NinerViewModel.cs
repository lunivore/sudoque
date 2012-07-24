using System.Collections.Generic;

namespace Sudoque.Game
{
    public class NinerViewModel
    {
        private readonly NinerId _id;
        private readonly IEnumerable<CellViewModel> _cells;

        public NinerViewModel(NinerId id, ICreateCellViewModels cellViewModelFactory)
        {
            _id = id;

            var cellModels = new List<CellViewModel>();

            var range = new[] { 0, 1, 2 };
            foreach (var row in range)
            foreach (var col in range)
            {
                cellModels.Add(cellViewModelFactory.Create(id, col, row));
            }
            _cells = cellModels;
        }

        public IEnumerable<CellViewModel> Cells
        {
            get { return _cells; }
        }

        public override string ToString()
        {
            return _id.ToString();
        }
    }
}