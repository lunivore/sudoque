namespace Sudoque.Game.Engine
{
    public class CellId
    {
        private readonly int _ninerId;
        private readonly int _withinNinerId;

        public CellId(int ninerId, int withinNinerId)
        {
            _ninerId = ninerId;
            _withinNinerId = withinNinerId;
        }

        public bool Equals(CellId other)
        {
            if (ReferenceEquals(this, other)) return true;
            return other._ninerId == _ninerId && other._withinNinerId == _withinNinerId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (CellId)) return false;
            return Equals((CellId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_ninerId*397) ^ _withinNinerId;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", _ninerId, _withinNinerId);
        }
    }
}
