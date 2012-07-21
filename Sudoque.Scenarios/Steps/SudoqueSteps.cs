using Microsoft.Practices.Unity;
using Sudoque.Scenarios.Framework;

namespace Sudoque.Scenarios.Steps
{
    public class SudoqueSteps
    {
        private readonly World _world;

        public SudoqueSteps(World world)
        {
            _world = world;
        }

        public void IsRunning()
        {
            var container = new AppFactory().CreateContainer();
            _world.PuzzleView = container.Resolve<StringBasedPuzzleView>();
        }

        public void ShouldLookLike(string grid)
        {
            _world.PuzzleView.ShouldMatch(grid);
        }

        public void HasAPuzzle(string grid)
        {
            IsRunning();
            _world.PuzzleView.Initialize(grid);
        }

        public void IsPlayed()
        {
            _world.PuzzleView.StartGame();
        }
    }
}