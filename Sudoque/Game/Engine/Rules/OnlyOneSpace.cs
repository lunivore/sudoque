using System.Collections.Generic;
using System.Linq;

namespace Sudoque.Game.Engine.Rules
{
    public class OnlyOneSpace : IMightBeAbleToHelp
    {
        public Hint HelpWith(IEnumerable<Cell> cells)
        {
            var cellList = cells.ToList();

            var emptyCells = cellList.ToList();
            emptyCells.RemoveAll(c => c.Actual.HasValue);

            if (emptyCells.Count == 1)
            {
                var missingNumber = Enumerable.Range(1, 9).Single(i => !cellList.Any(c => c.Actual.HasValue && c.Actual.Value == i));
                var hintText = string.Format("There's only one cell in this group that can be {0}.", missingNumber);
                return new Hint(hintText, cellList.Select(c => c.Id));
            }
            return Hint.None;
        }
    }
}
