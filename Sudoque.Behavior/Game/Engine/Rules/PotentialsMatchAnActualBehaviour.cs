using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sudoque.Game.Engine;

namespace Sudoque.Behavior.Game.Engine.Rules
{
    [TestFixture]
    public class PotentialsMatchAnActualBehaviour : RuleBehavior
    {
        [Test]
        public void ShouldTellUsIfPotentialsInANinerMatchAnActual()
        {
            // Given a Niner with at least one Actual
            var niner = CreateNineEmptyCellsInPlay();
            niner[0].RequestToggleNumber(1);

            // And the 4th cell of which has some Potentials that match
            niner[3].RequestToggleNumber(1);
            niner[3].RequestToggleNumber(4);
            niner[3].RequestToggleNumber(5);

            // When we ask the rule for help
            var rule = CreateRule();
            var hint = rule.HelpWith(niner);

            // Then it should tell us that not all our possibilities are possible
            Assert.AreEqual("This cell has more possibilities than are possible.", hint.Text);
            Assert.AreEqual(new CellId[] {niner[3].Id}, hint.CellIds);
        
        }

        [Test]
        public void ShouldNotMatchPotentialsIfNoActualsActuallyMatch()
        {
            // Given a Niner with at least one Actual
            var niner = CreateNineEmptyCellsInPlay();
            niner[0].RequestToggleNumber(1);

            // And a cell with potentials which don't match
            niner[3].RequestToggleNumber(2);
            niner[3].RequestToggleNumber(4);
            niner[3].RequestToggleNumber(5);

            // When we ask the rule for help
            var rule = CreateRule();
            var hint = rule.HelpWith(niner);

            // Then it should tell us that it can't help.
            Assert.AreEqual(Hint.None, hint);
        }

        public override IMightBeAbleToHelp CreateRule()
        {
            return new PotentialsMatchAnActual();
        }
    }
}
