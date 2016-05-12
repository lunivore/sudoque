using NUnit.Framework;
using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios
{
    [TestFixture]
    public class PlayerCanGetSimpleHints : Scenario
    {
        [Test]
        public void PlayerMakesAMistakeAndIsToldAboutIt()
        {
            GivenSudoque.IsPlayedWithAPuzzle(
                "..1 ... ..." + NL +
                "..2 ... ..." + NL +
                "..3 ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "..5 ... ..." + NL +
                "..6 ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
            WhenISelectACell.At(3, 2).AndToggle(1);
            ThenSudoque.ShouldLookLike(
                "..1 ... ..." + NL +
                "..2 ... ..." + NL +
                "..3 ... ..." + NL +
                "           " + NL +
                "..1 ... ..." + NL +
                "..5 ... ..." + NL +
                "..6 ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
            WhenIAskForHelp.Please();
            ThenTheHintText.ShouldTellMe("Two of the cells in this group are 1, you nit.");
        }

        [Test]
        public void NineCellsInASquareHaveOnlyOneGap()
        {
            GivenSudoque.IsPlayedWithAPuzzle(
                "4.1 ... ..." + NL +
                "582 ... ..." + NL +
                "673 ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "           " + NL +
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
            WhenIAskForHelp.Please();
            ThenTheHintText.ShouldTellMe("There's only one cell in this group that can be 9.");
        }

        [Test]
        public void OneSquareCanSeeEightNumbersAlready()
        {
            GivenSudoque.IsPlayedWithAPuzzle(
                "... ... ..." + NL +
                "... ... ..." + NL +
                "... 1.. ..." + NL +
                "           " + NL +
                "... 2.. ..." + NL +
                ".89 ... 67." + NL +
                "... ..5 ..." + NL +
                "           " + NL +
                "... 4.. ..." + NL +
                "... ... ..." + NL +
                "... ... ..." + NL);
            WhenIAskForHelp.Please();
            ThenTheHintText.ShouldTellMe("This cell can only be a 3.");
        }
    }
}
