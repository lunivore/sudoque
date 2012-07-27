using System.Collections.Generic;
using System.Linq;

namespace Sudoque.Game.Engine
{
    public class CellRepository : ILookAfterCells
    {
        private readonly Dictionary<CellId, Cell> _cells;

        public CellRepository()
        {
            _cells = new Dictionary<CellId, Cell>();           
            foreach(var niner in Enumerable.Range(0, 9))
            {
                foreach (var withinNiner in Enumerable.Range(0, 9))
                {
                    var cellId = new CellId(niner, withinNiner);
                    _cells.Add(cellId, new Cell(cellId));
                }
            }
        }

        public IEnumerable<NineCells> FetchCellsByRowColumnOrNiner()
        {
            var rows = FetchCellsByRow();
            var cols = FetchCellsByCol();
            var niners = FetchCellsByNiners();

            return new[] {rows, cols, niners}.SelectMany(cells => cells);
        }

        private IEnumerable<NineCells> FetchCellsByNiners()
        {
            return Enumerable.Range(0, 9)
                .Select(niner => new NineCells(Enumerable.Range(0, 9)
                .Select(withinNiner => _cells[new CellId(niner, withinNiner)])));
        }

        private IEnumerable<NineCells> FetchCellsByCol()
        {
            return Enumerable.Range(0, 9)
                .Select(column => new NineCells(Enumerable.Range(0, 9)
                .Select(row => _cells[new CellId(WhichNiner(column, row), WhichCellWithinNiner(column, row))])));
        }

        private IEnumerable<NineCells> FetchCellsByRow()
        {
            return Enumerable.Range(0, 9)
                .Select(row => new NineCells(Enumerable.Range(0, 9)
                .Select(column => _cells[new CellId(WhichNiner(column, row), WhichCellWithinNiner(column, row))])));
        }

        private int WhichCellWithinNiner(int column, int row)
        {
            var rowWithinCell = row % 3;
            var columnWithinCell = column%3;
            return rowWithinCell*3 + columnWithinCell;
        }

        private int WhichNiner(int column, int row)
        {
            var ninerRow = row / 3;
            var ninerColumn = column / 3;
            return ninerRow*3 + ninerColumn;
        }


        public Cell FetchCell(int ninerId, int withinNinerId)
        {
            return _cells[new CellId(ninerId, withinNinerId)];
        }
    }
}
