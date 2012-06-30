using Microsoft.Practices.Prism.Events;
using Sudoque.Game;

namespace Sudoque
{
    public class CellFactory : ICreateCells
    {
        private readonly IEventAggregator _events;

        public CellFactory(IEventAggregator events)
        {
            _events = events;
        }

        public CellViewModel Create(NinerId id, int column, int row)
        {
            return new CellViewModel(new CellId(id, column, row), _events);
        }
    }
}