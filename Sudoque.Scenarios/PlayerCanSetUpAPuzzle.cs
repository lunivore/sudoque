using NUnit.Framework;
using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios
{
    [TestFixture]
    public class PlayerCanSetUpAPuzzle : Scenario
    {

        [Test]
        public void APlayerCanSetUpAPuzzle()
        {
            GivenSudoque.IsRunning();
            WhenISelectACell.At(3, 4).AndToggle(1);
            ThenSudoque.ShouldLookLike(
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                ".1. ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
            WhenISelectACell.At(0, 8).AndToggle(1, 2, 3);
            ThenSudoque.ShouldLookLike(
                "... ... ..." + NL +
                "... ... ..." + NL +
                "..3 ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                ".1. ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
        }

        [Test]
        public void APlayerIsPreventedFromChangingThePuzzleWhilePlayingIt()
        {
            GivenSudoque.HasAPuzzle(
                "... ... ..." + NL +
                "... ... ..." + NL +
                "..3 ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
            WhenSudoque.IsPlayed();
            WhenISelectACell.At(0, 8).AndToggle(5);
            WhenISelectACell.At(4, 4).AndToggle(6);
            ThenSudoque.ShouldLookLike(
                "... ... ..." + NL +
                "... ... ..." + NL +
                "..3 ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... .6. ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
        }

        [Test]
        public void APlayerCanClearTheGridAndStartAgain()
        {
            GivenSudoque.IsPlayedWithAPuzzle(
                "... ... ..." + NL +
                "... ... ..." + NL +
                "..3 ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
            WhenSudoque.IsToldToCreateANewGame();
            ThenSudoque.ShouldBeEmpty();
            WhenISelectACell.At(4, 4).AndToggle(1, 2, 3);
            ThenSudoque.ShouldLookLike(
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... .3. ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
        }
    }
}
