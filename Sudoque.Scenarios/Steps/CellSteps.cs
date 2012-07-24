using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios.Steps
{
    public class CellSteps
    {
        private readonly World _world;

        public CellSteps(World world)
        {
            _world = world;
        }

        public ScenarioCell At(int ninerId, int cellId)
        {
            return new ScenarioCell(_world, ninerId, cellId);
        }
    }
}