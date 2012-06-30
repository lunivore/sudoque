namespace Sudoque.Game
{
    public class NinerFactory : ICreateNiners
    {
        private readonly ICreateCells _cellFactory;

        public NinerFactory(ICreateCells cellFactory)
        {
            _cellFactory = cellFactory;
        }

        public NinerViewModel Create(int column, int row)
        {
            return new NinerViewModel(new NinerId(column, row), _cellFactory);
        }
    }
}