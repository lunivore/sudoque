namespace Sudoque.Game
{
    public class CellId
    {
        private readonly NinerId _ninerId;
        private readonly int _column;
        private readonly int _row;

        public bool Equals(CellId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._ninerId, _ninerId) && other._column == _column && other._row == _row;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (CellId)) return false;
            return Equals((CellId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = _ninerId.GetHashCode();
                result = (result*397) ^ _column;
                result = (result*397) ^ _row;
                return result;
            }
        }

        public CellId(NinerId ninerId, int column, int row)
        {
            _ninerId = ninerId;
            _column = column;
            _row = row;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", _ninerId, _column, _row);
        }
    }
}