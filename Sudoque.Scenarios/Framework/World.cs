using Microsoft.Practices.Unity;

namespace Sudoque.Scenarios.Framework
{
    public class World
    {
        private StringBasedPuzzleView _puzzleView;
        private CellFinder _cellFinder;
        private Operations _operations;
        
        public void Initialize()
        {
            var container = new AppFactory().CreateContainer();
            _puzzleView = container.Resolve<StringBasedPuzzleView>();
            _cellFinder = container.Resolve<CellFinder>();
            _operations = container.Resolve<Operations>();
        }

        public Operations Operations
        {
            get { return _operations; }
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