using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios.Steps
{
    public class CellSelectionSteps
    {
        private readonly World _world;

        public CellSelectionSteps(World world)
        {
            _world = world;
        }

        public ScenarioCell Cell(int ninerId, int cellId)
        {
            return new ScenarioCell(_world, ninerId, cellId);
        }
    }
}