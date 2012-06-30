namespace Sudoque.Game
{
    public class NinerViewModelViewModelFactory : ICreateNinerViewModels
    {
        private readonly ICreateCellViewModels _cellViewModelFactory;

        public NinerViewModelViewModelFactory(ICreateCellViewModels cellViewModelFactory)
        {
            _cellViewModelFactory = cellViewModelFactory;
        }

        public NinerViewModel Create(int column, int row)
        {
            return new NinerViewModel(new NinerId(column, row), _cellViewModelFactory);
        }
    }
}