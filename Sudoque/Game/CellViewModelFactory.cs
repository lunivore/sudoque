using Microsoft.Practices.Prism.Events;
using Sudoque.Game;

namespace Sudoque
{
    public class CellViewModelFactory : ICreateCellViewModels
    {
        private readonly IEventAggregator _events;

        public CellViewModelFactory(IEventAggregator events)
        {
            _events = events;
        }

        public CellViewModel Create(NinerId id, int column, int row)
        {
            return new CellViewModel(new CellId(id, column, row), _events);
        }
    }
}