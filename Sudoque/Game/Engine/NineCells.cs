using System.Collections;
using System.Collections.Generic;

namespace Sudoque.Game.Engine
{
    public class NineCells : IEnumerable<Cell>
    {
        private readonly IEnumerable<Cell> _cells;

        public NineCells(IEnumerable<Cell> cells)
        {
            _cells = cells;
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}
