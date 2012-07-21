namespace Sudoque.Game
{
    public class CellId
    {
        private readonly NinerId _ninerId;
        private readonly int _id;

        public CellId(NinerId ninerId, int column, int row)
        {
            _ninerId = ninerId;
            _id = row*3 + column;
        }

        public bool Equals(CellId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other._id == _id && Equals(other._ninerId, _ninerId);
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
                return (_id*397) ^ _ninerId.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("Cell[{0}, {1}]", _ninerId, _id);
        }
    }
}