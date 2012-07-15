using System;
using NUnit.Framework;
using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios
{
    [TestFixture]
    public class UserCanEnterElementsIntoTheGrid : Scenario
    {
        private static readonly string NL = Environment.NewLine;

        [Test]
        public void AUserCanSetUpAPuzzle()
        {
            GivenSudoque.IsRunning();
            WhenISelect.Cell(3, 4).AndToggle(1);
            ThenSudoque.ShouldLookLike(
                "... ... ..." + NL +
                "... ... 1.." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
            WhenISelect.Cell(0, 8).AndToggle(1, 2, 3);
            ThenSudoque.ShouldLookLike(
                "... ... ..." + NL +
                "... ... 1.." + NL +
                ".3. ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
        }

        [Test]
        public void AUserIsPreventedFromChangingThePuzzleWhilePlayingIt()
        {
            GivenSudoque.HasAPuzzle(
                "... ... ..." + NL +
                "... ... 1.." + NL +
                ".3. ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
        }
    }
}
