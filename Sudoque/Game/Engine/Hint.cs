using System.Collections.Generic;

namespace Sudoque.Game.Engine
{
    public class Hint
    {
        public static Hint None = new Hint("I'm sorry, I wasn't able to find a solution! Are you sure this can be solved?", new CellId[0]);

        private readonly string _text;
        private readonly IEnumerable<CellId> _cellIds;
        
        public Hint(string text, IEnumerable<CellId> cellIds)
        {
            _text = text;
            _cellIds = cellIds;
        }

        public IEnumerable<CellId> CellIds
        {
            get { return _cellIds; }
        }

        public string Text
        {
            get { return _text; }
        }
    }
}