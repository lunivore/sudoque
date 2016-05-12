using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sudoque.Game.Engine;
using Sudoque.Game.Engine.Rules;

namespace Sudoque.Behavior.Game.Engine.Rules
{
    [TestFixture]
    public class OnlyOneSpaceBehavior : RuleBehavior
    {
        [Test]
        public void ShouldProvideAHintIfTheNineCellsOnlyHaveOneSpace()
        {
            // Given eight cells with Actuals
            var cellsWithActuals = CreateCellsWithActuals(1, 2, 3, 4, 5, 6, 7, 8);
            
            // And one without
            var cellWithout = new Cell(new CellId(-1, -1));

            // When we pass all of them to the rule
            var allCells = new List<Cell>();
            allCells.AddRange(cellsWithActuals);
            allCells.Add(cellWithout);

            var rule = new OnlyOneSpace();
            var hint = rule.HelpWith(allCells);

            // Then the rule should give us back some text about the only empty cell having to be the 9,
            // containing all 9 cells in the hint.
            Assert.IsTrue(hint.Text.Contains("only one"));
            Assert.IsTrue(hint.Text.Contains("9"));
            CollectionAssert.AreEquivalent(hint.CellIds, allCells.Select(c => c.Id));
        }

        [Test]
        public void ShouldTellUsItCantHelpIfThereIsMoreThanOneSpace()
        {
            // Given some cells with actuals and some without
            var cellsWithActuals = CreateCellsWithActuals(1, 2, 3, 4, 5, 6, 7);
            var cellsWithout = new List<Cell> {new Cell(new CellId(-1, -1)), new Cell(new CellId(-1, -1))};

            // When we pass all of them to the rule
            var allCells = new List<Cell>();
            allCells.AddRange(cellsWithActuals);
            allCells.AddRange(cellsWithout);

            var rule = new OnlyOneSpace();
            var hint = rule.HelpWith(allCells);

            // Then the rule should tell us that it can't help
            Assert.AreEqual(Hint.None, hint);
        }

        public override IMightBeAbleToHelp CreateRule()
        {
            return new OnlyOneSpace();
        }
    }
}
