namespace Sudoque.Game
{
    public class NinerViewModelFactory : ICreateNinerViewModels
    {
        private readonly ICreateCellViewModels _cellViewModelFactory;

        public NinerViewModelFactory(ICreateCellViewModels cellViewModelFactory)
        {
            _cellViewModelFactory = cellViewModelFactory;
        }

        public NinerViewModel Create(int ninerId)
        {
            return new NinerViewModel(ninerId, _cellViewModelFactory);
        }
    }
}