using System;

namespace Sudoque.Scenarios.Framework
{
    public class ScenarioCell
    {
        private readonly World _world;
        private readonly int _ninerId;
        private readonly int _cellId;

        public ScenarioCell(World world, int ninerId, int cellId)
        {
            _world = world;
            _ninerId = ninerId;
            _cellId = cellId;
        }

        public void AndToggle(params int[] selection)
        {
            Array.ForEach(selection, s => _world.PuzzleView.ToggleCell(_ninerId, _cellId, s));
        }
    }
}