using System.Linq;
using Sudoque.Game;

namespace Sudoque.Scenarios.Framework
{
    public class CellFinder
    {
        private readonly PuzzleViewModel _viewModel;

        public CellFinder(PuzzleViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public CellViewModel FromNinerAndCellId(int ninerId, int cellId)
        {
            var niner = _viewModel.Niners.ElementAt(ninerId);
            var cell = niner.Cells.ElementAt(cellId);
            return cell;
        }

        public CellViewModel FromColumnAndRow(int column, int row)
        {
            var niner = _viewModel.Niners.ElementAt((row / 3) * 3 + column / 3);
            var cell = niner.Cells.ElementAt((row % 3) * 3 + column % 3);
            return cell;
        }
    }
}