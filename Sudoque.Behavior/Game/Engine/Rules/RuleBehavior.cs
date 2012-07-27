using System.Collections.Generic;
using System.Linq;
using Sudoque.Game.Engine;

namespace Sudoque.Behavior.Game.Engine.Rules
{
    public abstract class RuleBehavior
    {
        protected IEnumerable<Cell> CreateCellsWithActuals(params int[] actuals)
        {
            return actuals.Select(i =>
                                      {
                                          var cell = new Cell(new CellId(-1, -1));
                                          cell.RequestToggleNumber(i);
                                          return cell;
                                      });
        }
    }
}