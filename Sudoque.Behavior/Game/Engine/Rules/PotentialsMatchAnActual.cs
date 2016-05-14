using System.Collections.Generic;
using System.Linq;
using Sudoque.Game.Engine;

namespace Sudoque.Behavior.Game.Engine.Rules
{
    public class PotentialsMatchAnActual : IMightBeAbleToHelp
    {
        public Hint HelpWith(IEnumerable<Cell> niner)
        {
            var candidates = niner.Where(c => c.Potentials.Any());
            var actualValues = niner.Where(c => c.Actual.HasValue).Select(c => c.Actual.GetValueOrDefault());

            var matches = candidates.Where(c => c.Potentials.Any(actualValues.Contains));

            return matches.Any() ? 
                new Hint(
                    "This cell has more possibilities than are possible.",
                    new CellId[] {matches.First().Id}) : 
                Hint.None;
        }
    }
}