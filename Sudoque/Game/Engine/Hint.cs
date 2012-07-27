using System.Collections.Generic;

namespace Sudoque.Game.Engine
{
    public class Hint
    {
        public static Hint None = new Hint("I'm sorry, I wasn't able to find a solution! Are you sure this can be solved?", new List<Cell>());

        private readonly string _text;
        private readonly IEnumerable<Cell> _cells;
        
        public Hint(string text, IEnumerable<Cell> cells)
        {
            _text = text;
            _cells = cells;
        }

        public IEnumerable<Cell> Cells
        {
            get { return _cells; }
        }

        public string Text
        {
            get { return _text; }
        }
    }
}