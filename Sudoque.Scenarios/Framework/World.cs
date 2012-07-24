using Microsoft.Practices.Unity;

namespace Sudoque.Scenarios.Framework
{
    public class World
    {
        private StringBasedPuzzleView _puzzleView;
        private CellFinder _cellFinder;
        private Commands _commands;

        public void Initialize()
        {
            var container = new AppFactory().CreateContainer();
            _puzzleView = container.Resolve<StringBasedPuzzleView>();
            _cellFinder = container.Resolve<CellFinder>();
            _commands = container.Resolve<Commands>();
        }

        public Commands Commands
        {
            get { return _commands; }
        }

        public CellFinder CellFinder
        {
            get { return _cellFinder; }
        }

        public StringBasedPuzzleView PuzzleView
        {
            get { return _puzzleView; }
        }

    }
}