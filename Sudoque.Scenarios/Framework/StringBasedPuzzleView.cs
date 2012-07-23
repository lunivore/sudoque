using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sudoque.Game;

namespace Sudoque.Scenarios.Framework
{
    public class StringBasedPuzzleView
    {
        private readonly PuzzleViewModel _viewModel;

        public StringBasedPuzzleView(PuzzleViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void ShouldMatch(string expected)
        {
            var currentGrid = new StringBuilder();

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)                
                {
                    var niner = FindNiner( row, col );
                    var cell = FindCellInNiner(row % 3, col % 3, niner);

                    currentGrid.Append(cell.Actual.Equals(string.Empty) ? "." : cell.Actual);
                    AppendVerticalSeparators(currentGrid, col);
                }
                AppendHorizontalSeparators(currentGrid, row);
            }
            var actual = currentGrid.ToString();
            Assert.AreEqual(expected, actual);
        }

        private NinerViewModel FindNiner( int row, int col)
        {
            return _viewModel.Niners.ElementAt( row / 3 * 3 + col / 3); // Truncate to block of rows, then apply offset per column
        }

        private CellViewModel FindCellInNiner(int row, int col, NinerViewModel niner)
        {
            return niner.Cells.ElementAt( row * 3 + col );
        }
        
        public void Initialize(string grid)
        {
            var gridWithoutSeparators = grid
                .Replace(" ", string.Empty)
                .Replace(Environment.NewLine, string.Empty);
            
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    var character = gridWithoutSeparators.ElementAt(row*9 + col);
                    if (character != '.')
                    {
                        var niner = FindNiner(row, col);
                        var cell = FindCellInNiner( row % 3, col % 3, niner );
                        cell.Selected = true;
                        _viewModel.NumberRequest.Execute(character.ToString());
                    }
                }
            }
        }

        private void AppendHorizontalSeparators(StringBuilder currentGrid, int row)
        {
            currentGrid.Append(Environment.NewLine);
            if (row == 2 || row == 5)
            {
                currentGrid.Append("           ");
                currentGrid.Append(Environment.NewLine);
            }
        }

        private static void AppendVerticalSeparators(StringBuilder currentGrid, int col)
        {
            if (col == 2 || col == 5)
            {
                currentGrid.Append(" ");
            }            
        }

        public void ToggleCell(int ninerId, int cellId, int number)
        {
            var niner = _viewModel.Niners.ElementAt(ninerId);
            var cell = niner.Cells.ElementAt(cellId);
            cell.GotFocus.Execute("whatever");
            _viewModel.NumberRequest.Execute(number.ToString());
        }

        public void StartGame()
        {
            _viewModel.PlayGameRequest.Execute(null);
        }
    }
}
