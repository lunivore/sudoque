using System.Collections.Generic;
using System.Linq;

namespace Sudoque.Game.Engine.Rules
{
    public class OnlyOnePotential : IMightBeAbleToHelp
    {
        public Hint HelpWith(IEnumerable<Cell> cells)
        {
            var actuals = cells.SelectMany(
                c => c.Actual.HasValue ? 
                    new[] {c.Actual.Value} : 
                    new int[0]);

            var copiedCandidates = cells.Select((c, i) => c.Copy()).ToList();
            copiedCandidates.RemoveAll(c => c.Actual.HasValue);

            foreach (var copiedCandidate in copiedCandidates)
            {
                if (!copiedCandidate.Potentials.Any())
                {
                    for (int i = 1; i < 10; i++)
                    {
                        copiedCandidate.RequestToggleNumber(i);
                    }
                }
            }

            foreach (var actual in actuals)
            {
                foreach(var cell in copiedCandidates)
                {
                    cell.RemovePotential(actual);
                    if (cell.Actual.HasValue)
                    {
                        return new Hint(string.Format("This cell can only be a {0}", cell.Actual.Value),
                            new[] {cell.Id});
                    }
                }
            }

            return Hint.None;
        }
    }
}
