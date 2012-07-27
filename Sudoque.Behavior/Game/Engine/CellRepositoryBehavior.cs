using System.Linq;
using NUnit.Framework;
using Sudoque.Game.Engine;

namespace Sudoque.Behavior.Game.Engine
{
    [TestFixture]
    public class CellRepositoryBehavior
    {
        [Test]
        public void ShouldBeAbleToSeparateCellsIntoRows()
        {
            // Given a repository with all the cells in it
            var repository = new CellRepository();

            // When we ask for the rows, columns and niners
            var nineCellsCollection = repository.FetchCellsByRowColumnOrNiner();

            // One of them should be the 2nd row (index 1)
            var foundRow2 = false;
            foreach (var nineCells in nineCellsCollection)
            {
                var expected = new NineCells(new[]
                                                 {
                                                    repository.FetchCell(0, 3),
                                                    repository.FetchCell(0, 4),
                                                    repository.FetchCell(0, 5),
                                                    repository.FetchCell(1, 3),
                                                    repository.FetchCell(1, 4),
                                                    repository.FetchCell(1, 5),
                                                    repository.FetchCell(2, 3),
                                                    repository.FetchCell(2, 4),
                                                    repository.FetchCell(2, 5)
                                                 });
                var intersectionWithRow2 = nineCells.Intersect(expected).Count();                
                if (intersectionWithRow2 == 9)
                {
                    foundRow2 = true;
                }
            }
            Assert.IsTrue(foundRow2);
        }

        [Test]
        public void ShouldBeAbleToSeparateCellsIntoColumns()
        {
            // Given a repository with all the cells in it
            var repository = new CellRepository();

            // When we ask for the rows, columns and niners
            var nineCellsCollection = repository.FetchCellsByRowColumnOrNiner();

            // One of them should be the 5th column (index 4)
            var foundColumn5 = false;
            foreach (var nineCells in nineCellsCollection)
            {
                var expected = new NineCells(new[]
                                                 {
                                                    repository.FetchCell(1, 2),
                                                    repository.FetchCell(1, 5),
                                                    repository.FetchCell(1, 8),
                                                    repository.FetchCell(4, 2),
                                                    repository.FetchCell(4, 5),
                                                    repository.FetchCell(4, 8),
                                                    repository.FetchCell(7, 2),
                                                    repository.FetchCell(7, 5),
                                                    repository.FetchCell(7, 8)
                                                 });
                if (nineCells.Intersect(expected).Count() == 9)
                {
                    foundColumn5 = true;
                }
            }
            Assert.IsTrue(foundColumn5);
        }

        [Test]
        public void ShouldBeAbleToSeparateCellsIntoNiners()
        {
            // Given a repository with all the cells in it
            var repository = new CellRepository();

            // When we ask for the rows, columns and niners
            var nineCellsCollection = repository.FetchCellsByRowColumnOrNiner();

            // One of them should be the 5th column (index 4)
            var foundNiner0 = false;
            foreach (var nineCells in nineCellsCollection)
            {
                var expected = new NineCells(new[]
                                                 {
                                                    repository.FetchCell(0, 0),
                                                    repository.FetchCell(0, 1),
                                                    repository.FetchCell(0, 2),
                                                    repository.FetchCell(0, 3),
                                                    repository.FetchCell(0, 4),
                                                    repository.FetchCell(0, 5),
                                                    repository.FetchCell(0, 6),
                                                    repository.FetchCell(0, 7),
                                                    repository.FetchCell(0, 8)
                                                 });
                if (nineCells.Intersect(expected).Count() == 9)
                {
                    foundNiner0 = true;
                }
            }
            Assert.IsTrue(foundNiner0);
        }
    }
}
