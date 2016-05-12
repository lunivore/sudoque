using System.Collections.Generic;
using System.Linq;

namespace Sudoque.Game.Engine.Rules
{
    public class ActualsCollide : IMightBeAbleToHelp
    {
        public Hint HelpWith(IEnumerable<Cell> cells)
        {
            var cellList = cells.ToList();
            foreach (var actual in Enumerable.Range(1, 9))
            {
                var count = cellList.Count(c => c.Actual.HasValue && c.Actual.Value == actual);
                if (count > 1)
                {
                    var hintText = string.Format("Two of the cells in this group are {0}, you nit.", actual);
                    return new Hint(hintText, cellList.Select(c => c.Id));
                }
            }
            return Hint.None;
        }
    }
}
