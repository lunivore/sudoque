namespace Sudoque.Game
{
    public class NinerId
    {
        private readonly int _id;

        public NinerId(int column, int row)
        {
            _id = row*3 + column;
        }

        public bool Equals(NinerId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other._id == _id;
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
            return _id;
        }

        public override string ToString()
        {
            return string.Format("Niner[{0}]", _id);
        }
    }
}