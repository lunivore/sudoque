namespace Sudoque.Game
{
    public class NinerId
    {
        private readonly int _column;
        private readonly int _row;

        public NinerId(int column, int row)
        {
            _column = column;
            _row = row;
        }

        public override string ToString()
        {
            return (_row*3 + _column).ToString();
        }

        public bool Equals(NinerId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other._column == _column && other._row == _row;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NinerId)) return false;
            return Equals((NinerId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_column*397) ^ _row;
            }
        }
    }
}