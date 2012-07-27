using Microsoft.Practices.Prism.Events;
using Sudoque.Game;
using Sudoque.Game.Engine;

namespace Sudoque
{
    public class CellViewModelFactory : ICreateCellViewModels
    {
        private readonly IEventAggregator _events;
        private readonly ILookAfterCells _cells;

        public CellViewModelFactory(IEventAggregator events, ILookAfterCells cells)
        {
            _events = events;
            _cells = cells;
        }

        public CellViewModel Create(int ninerId, int cellId)
        {
            return new CellViewModel(_cells.FetchCell(ninerId, cellId), _events);
        }
    }
}