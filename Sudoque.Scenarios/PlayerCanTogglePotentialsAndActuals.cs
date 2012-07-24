using NUnit.Framework;
using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios
{
    [TestFixture]
    public class PlayerCanTogglePotentialsAndActuals : Scenario
    {
        [Test]
        public void PlayerCanAddAndRemovePotentials()
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
            WhenISelectACell.At(1, 4).AndToggle(1, 2, 3, 4);
            ThenTheCell.At(1, 4).ShouldHavePotentials(1, 2, 3, 4)
                                .AndActual(None);

            WhenISelectACell.At(1, 4).AndToggle(1, 3);
            ThenTheCell.At(1, 4).ShouldHavePotentials(2, 4)
                                .AndActual(None);

            AndSudoque.ShouldLookLike(
                "... ... ..." + NL +
                "... .#. ..." + NL +
                "..3 ... ..." + NL +
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
        public void OnePotentialBecomesAnActual()
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

            WhenISelectACell.At(1, 5).AndToggle(4);
            ThenTheCell.At(1, 5).ShouldHavePotentials()
                                .AndActual(4);

            AndSudoque.ShouldLookLike(
                "... ... ..." + NL +
                "... ..4 ..." + NL +
                "..3 ... ..." + NL +
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
