using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios.Steps
{
    public class CellSelectionSteps
    {
        public ScenarioCell Cell(int ninerId, int cellId)
        {
            return new ScenarioCell(ninerId, cellId);
        }
    }
}