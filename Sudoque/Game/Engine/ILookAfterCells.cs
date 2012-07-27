using System.Collections.Generic;

namespace Sudoque.Game.Engine
{
    public interface ILookAfterCells
    {
        IEnumerable<NineCells> FetchCellsByRowColumnOrNiner();
        Cell FetchCell(int ninerId, int withinNinerId);
    }
}