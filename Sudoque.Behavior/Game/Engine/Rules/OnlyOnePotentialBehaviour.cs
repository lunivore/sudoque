using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sudoque.Game;
using Sudoque.Game.Engine;
using Sudoque.Game.Engine.Rules;

namespace Sudoque.Behavior.Game.Engine.Rules
{
    [TestFixture]
    public class OnlyOnePotentialBehaviour : RuleBehavior
    {
        [Test]
        public void ShouldTellUsIfASquareHasOnlyOnePotentialLeft()
        {
            // Given some cells, the first of which has potentials 8 and 9
            // and the second is an actual 9
            var cells = CreateNineEmptyCellsInPlay();
            cells[0].RequestToggleNumber(8);
            cells[0].RequestToggleNumber(9);
            cells[1].RequestToggleNumber(9);
            
            // When we apply the rule to that group
            var rule = new OnlyOnePotential();
            var hint = rule.HelpWith(cells);

            // Then the rule should return a hint that the 1st cell can be reduced to an 8.
            Assert.AreEqual(hint.CellIds.First(), cells[0].Id);
            Assert.AreEqual("This cell can only be a 8", hint.Text);
        }

        [Test]
        public void ShouldTellUsIfAnEmptySquareOnlyHasOnePotentialLeft()
        {
            // Given some cells, all of which are filled with actuals
            // except the third, which is missing "3"
            var cells = CreateCellsWithActuals(1, 2, 3, 4, 5, 6, 7, 8, 9);
            cells[2].RequestToggleNumber(3);

            // When we apply the rule to that group
            var rule = new OnlyOnePotential();
            var hint = rule.HelpWith(cells);

            // Then the rule should return a hint that the 3rd cell can only be a 3.
            Assert.AreEqual(hint.CellIds.First(), cells[2].Id);
            Assert.AreEqual("This cell can only be a 3", hint.Text);
        }

        public override IMightBeAbleToHelp CreateRule()
        {
            return new OnlyOnePotential();
        }
    }
}
