using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sudoque.Game;

namespace Sudoque.Scenarios.Framework
{
    public class StringBasedPuzzleView
    {
        private static readonly int[] Separators = new[] {2, 5};
        private readonly CellFinder _cellFinder;
        private readonly Commands _commands;

        public StringBasedPuzzleView(CellFinder cellFinder, Commands commands)
        {
            _cellFinder = cellFinder;
            _commands = commands;
        }

        public void ShouldMatch(string expected)
        {
            var currentGrid = new StringBuilder();

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)                
                {
                    var cell = _cellFinder.FromColumnAndRow(col, row);

                    currentGrid.Append(CharacterForCell(cell));
                    AppendVerticalSeparators(currentGrid, col);
                }
                AppendHorizontalSeparators(currentGrid, row);
            }
            var actual = currentGrid.ToString();
            Assert.AreEqual(expected, actual);
        }

        public void SetUpWith(string grid)
        {
            var gridWithoutSeparators = grid
                .Replace(" ", string.Empty)
                .Replace(Environment.NewLine, string.Empty);
            
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    var character = gridWithoutSeparators.ElementAt(row*9 + column);
                    if (character != '.')
                    {
                        var cell = _cellFinder.FromColumnAndRow(column, row);
                        cell.Selected = true;
                        _commands.PressNumber(int.Parse(character.ToString()));
                    }
                }
            }
        }

        private void AppendHorizontalSeparators(StringBuilder currentGrid, int row)
        {
            currentGrid.Append(Environment.NewLine);
            if (Separators.Contains(row))
            {
                currentGrid.Append("           ");
                currentGrid.Append(Environment.NewLine);
            }
        }

        private static void AppendVerticalSeparators(StringBuilder currentGrid, int column)
        {
            if (Separators.Contains(column))
            {
                currentGrid.Append(" ");
            }            
        }

        private static string CharacterForCell(CellViewModel cell)
        {
            if (!cell.Actual.Equals(string.Empty))
            {
                return cell.Actual;
            }
            if (!cell.Potentials.Equals(string.Empty))
            {
                return "#";
            }
            return ".";
        }
    }
}
