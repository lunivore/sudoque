using System.Collections.Generic;
using System.Linq;

namespace Sudoque.Game.Engine
{
    public class Cell
    {
        private readonly CellId _id;
        private readonly HashSet<int> _potentials;
        private Mode _mode = Mode.NewGame;
        private bool _fixed;

        public Cell(CellId id)
        {
            _id = id;
            _potentials = new HashSet<int>();
        }

        public CellId Id { get { return _id; } }

        public void ChangeMode(Mode mode)
        {
            if (mode == Mode.NewGame)
            {
                _potentials.Clear();
                _fixed = false;
            }
            else if (mode == Mode.PlayGame && _potentials.Count > 0)
            {
                _fixed = true;
            }
            _mode = mode;
        }

        public bool Fixed
        {
            get { return _mode == Mode.NewGame || _fixed == true; } 
        }

        public IEnumerable<int> Potentials
        {
            get 
            {
                if (_potentials.Count < 2)
                {
                    return new List<int>();
                }
                var list = _potentials.ToList();
                list.Sort();
                return list;
            }
        }

        public int? Actual
        {
            get
            {
                if (_potentials.Count != 1)
                {
                    return null;
                }
                return _potentials.First();
            }
        }

        public void RequestToggleNumber(int number)
        {
            if (_mode == Mode.NewGame && !_potentials.Remove(number))
            {
                _potentials.Clear();
                _potentials.Add(number);
            }
            else if (!Fixed && !_potentials.Remove(number))
            {
                _potentials.Add(number);
            }
        }

        public override string ToString()
        {
            return string.Format("Cell[{0}]", _id);
        }

        public Cell Copy()
        {
            var copy = new Cell(_id);
            foreach (var potential in _potentials)
            {
                copy._potentials.Add(potential);
            }
            copy._mode = _mode;
            copy._fixed = _fixed;
            return copy;
        }

        public void RemovePotential(int number)
        {
            _potentials.Remove(number);
        }
    }
}