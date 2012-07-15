namespace Sudoque.Game
{
    public class NinerViewModelFactory : ICreateNinerViewModels
    {
        private readonly ICreateCellViewModels _cellViewModelFactory;

        public NinerViewModelFactory(ICreateCellViewModels cellViewModelFactory)
        {
            _cellViewModelFactory = cellViewModelFactory;
        }

        public NinerViewModel Create(int column, int row)
        {
            return new NinerViewModel(new NinerId(column, row), _cellViewModelFactory);
        }
    }
}