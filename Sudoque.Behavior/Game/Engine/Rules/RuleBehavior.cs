using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sudoque.Game;
using Sudoque.Game.Engine;

namespace Sudoque.Behavior.Game.Engine.Rules
{
    public abstract class RuleBehavior
    {
        [Test]
        public void ShouldNotBeAbleToHelpWithEmptyCells()
        {
            // Given empty cells
            var cells = CreateNineEmptyCellsInPlay();

            // When we apply the rules to the empty cells
            var rule = CreateRule();
            var hint = rule.HelpWith(cells);

            // Then there should be no hint.
            Assert.AreEqual(Hint.None, hint);
        }

        public abstract IMightBeAbleToHelp CreateRule();

        protected IList<Cell> CreateCellsWithActuals(params int[] actuals)
        {
            return actuals.Select(i =>
                                      {
                                          var cell = new Cell(new CellId(i, -1));
                                          cell.ChangeMode(Mode.PlayGame);
                                          cell.RequestToggleNumber(i);
                                          return cell;
                                      }).ToList();
        }

        protected IList<Cell> CreateNineEmptyCellsInPlay()
        {
            var cells = new List<Cell>();
            for(int i = 0; i < 9; i++)
            {
                var cell = new Cell(new CellId(0, i));
                cell.ChangeMode(Mode.PlayGame);
                cells.Add(cell);
            }
            return cells;
        }
    }
}