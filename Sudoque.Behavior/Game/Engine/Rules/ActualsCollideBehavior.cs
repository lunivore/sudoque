using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sudoque.Game.Engine;
using Sudoque.Game.Engine.Rules;

namespace Sudoque.Behavior.Game.Engine.Rules
{
    [TestFixture]
    public class ActualsCollideBehavior : RuleBehavior
    {
        [Test]
        public void ShouldTellUsIfTwoActualsInAGroupAreTheSame()
        {
            // Given a group containing two cells with the same actuals
            var cells = CreateCellsWithActuals(2, 3, 4, 5, 6, 7, 8, 9, 9).ToList();

            // When we ask the rule to help
            var rule = new ActualsCollide();
            var hint = rule.HelpWith(cells);

            // Then it should tell us about the two cells and contain all 9 cells
            Assert.IsTrue(hint.Text.Contains("Two of the cells"));
            Assert.IsTrue(hint.Text.Contains("9"));

            CollectionAssert.AreEquivalent(hint.Cells, cells);
        }

        [Test]
        public void ShouldTellUsIfItCantHelp()
        {
            // Given a group with no duplicated actuals but potentially empty cells
            var cellsWithActuals = CreateCellsWithActuals(2, 3, 4, 5, 6, 7);
            var cellsWithout = new List<Cell> {new Cell(new CellId(-1, -1)), new Cell(new CellId(-1, -1)), new Cell(new CellId(-1, -1))};

            // When we ask the rule to help
            var rule = new ActualsCollide();
            var cells = new List<Cell>();
            cells.AddRange(cellsWithActuals);
            cells.AddRange(cellsWithout);
            var hint = rule.HelpWith(cells);

            // Then it should tell us it can't help
            Assert.AreEqual(Hint.None, hint);
        }
    }
}
