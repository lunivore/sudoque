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
            ThenTheHintText.ShouldTellMe("Two of the cells in this group are 1");
        }
    }
}
