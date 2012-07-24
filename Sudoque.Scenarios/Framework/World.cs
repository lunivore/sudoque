namespace Sudoque.Scenarios.Framework
{
    public class World
    {
        public StringBasedPuzzleView PuzzleView { get; set; }

        public CellFinder CellFinder { get; set; }

        public Commands Commands { get; set; }
    }
}