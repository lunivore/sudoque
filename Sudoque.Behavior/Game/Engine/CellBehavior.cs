using System.Linq;
using NUnit.Framework;
using Sudoque.Game;
using Sudoque.Game.Engine;

namespace Sudoque.Behavior.Game.Engine
{
    [TestFixture]
    public class CellBehavior
    {
        [TestCase]
        public void ShouldNotHaveAnythingInToStartWith()
        {
            // Given a cell's been created
            var cell = new Cell(new CellId(-1, -1));

            // Then it should have nothing in it
            Assert.Null(cell.Actual);
            Assert.IsEmpty(cell.Potentials.ToList());
        }

        [TestCase]
        public void ShouldNotAllowPotentialsForANewGame()
        {
            // Given a cell has just been created
            var cell = new Cell(new CellId(-1, -1));

            // When we toggle a number then another one
            cell.RequestToggleNumber(1);
            cell.RequestToggleNumber(2);

            // Then there should be no potentials
            Assert.IsEmpty(cell.Potentials.ToList());

            // And one actual, which should be 2.
            Assert.AreEqual(cell.Actual, 2);
        }

        [TestCase]
        public void ShouldFixTheNumberIfItHasAnActualWhenGameIsStarted()
        {
            // Given a cell is created and an actual is added
            var cell = new Cell(new CellId(-1, -1));
            cell.RequestToggleNumber(3);

            // When the mode is changed to playing the game
            cell.ChangeMode(Mode.PlayGame);

            // Then the cell should be fixed with that number
            Assert.IsTrue(cell.Fixed);
            Assert.AreEqual(3, cell.Actual);
        }

        [TestCase]
        public void ShouldNotAllowFixedNumbersToBeToggled()
        {
            // Given a fixed number
            var cell = new Cell(new CellId(-1, -1));
            cell.RequestToggleNumber(3);
            cell.ChangeMode(Mode.PlayGame);

            // When we toggle the number
            cell.RequestToggleNumber(5);

            // Then nothing should change
            Assert.AreEqual(3, cell.Actual);
            Assert.IsEmpty(cell.Potentials);
        }

        [TestCase]
        public void ShouldHavePotentialsIfMoreThanOneNumberToggled()
        {
            // Given a cell is created and the game is started
            var cell = new Cell(new CellId(-1, -1));
            cell.ChangeMode(Mode.PlayGame);

            // When one number is toggled
            cell.RequestToggleNumber(1);

            // Then it should be an actual
            Assert.AreEqual(1, cell.Actual);
            Assert.IsEmpty(cell.Potentials.ToList());

            // When a second number is toggled
            cell.RequestToggleNumber(2);

            // Then they should be potentials
            Assert.AreEqual(2, cell.Potentials.Count());
            Assert.AreEqual(1, cell.Potentials.First());
            Assert.AreEqual(2, cell.Potentials.ElementAt(1));
            Assert.Null(cell.Actual);
        }

        [TestCase]
        public void ShouldRemoveNumbersWhenToggledTwice()
        {
            // Given a cell with a few numbers in
            var cell = new Cell(new CellId(-1, -1));
            cell.ChangeMode(Mode.PlayGame);
            cell.RequestToggleNumber(3);
            cell.RequestToggleNumber(4);
            cell.RequestToggleNumber(5);

            // When we toggle again
            cell.RequestToggleNumber(5);

            // Then it should remove the number
            Assert.False(cell.Potentials.Contains(5));
        }

        [TestCase]
        public void ShouldClearFixedNumbersWhenGameIsRecreated()
        {
            // Given a cell with a fixed number in
            var cell = new Cell(new CellId(-1, -1));
            cell.RequestToggleNumber(8);
            cell.ChangeMode(Mode.PlayGame);

            // When we create a new game
            cell.ChangeMode(Mode.NewGame);

            // Then it should have emptied
            Assert.Null(cell.Actual);

            // When we start the game again
            cell.ChangeMode(Mode.PlayGame);

            // Then it should still not be fixed
            Assert.IsFalse(cell.Fixed);
        }

        [TestCase]
        public void ShouldClearPotentialsWhenGameIsRecreated()
        {
            // Given a cell with some numbers in
            var cell = new Cell(new CellId(-1, -1));
            cell.ChangeMode(Mode.PlayGame);
            cell.RequestToggleNumber(6);
            cell.RequestToggleNumber(7);
            cell.RequestToggleNumber(8);

            // When we start a new game
            cell.ChangeMode(Mode.NewGame);

            // Then the cell should be cleared
            Assert.IsEmpty(cell.Potentials);
        }

        public void ShouldBeAbleToCopyItselfWithTheSamePotentialsActualsAndMode()
        {
            // Given a cell with some potentials
            var cell = new Cell(new CellId(-1, -1));
            cell.ChangeMode(Mode.PlayGame);
            cell.RemovePotential(6);
            cell.RemovePotential(7);

            // When we copy the cell
            var copy = cell.Copy();

            // Then the copy should have the same potentials
            Assert.AreEqual(new int[]{1, 2, 3, 4, 5, 8, 9}.ToList(), cell.Potentials);

            // And be in the same mode
            copy.RequestToggleNumber(5);
            Assert.AreEqual(new int[]{1, 2, 3, 4, 8, 9}.ToList(), cell.Potentials);
        }
    }
}
