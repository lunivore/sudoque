using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Events;

namespace Sudoque.Game.Engine
{
    public class Solver
    {
        private readonly ILookAfterCells _cells;
        private readonly IEnumerable<IMightBeAbleToHelp> _rules;
        private readonly HintProvidedEvent _hintProviderEvent;
        
        public Solver(IEventAggregator events, ILookAfterCells cells, IEnumerable<IMightBeAbleToHelp> rules)
        {
            _cells = cells;
            _rules = rules;
            _hintProviderEvent = events.GetEvent<HintProvidedEvent>();
            events.GetEvent<HintRequestEvent>().Subscribe(o => ProvideHint(), true);
        }

        private void ProvideHint()
        {
            var sequences = _cells.FetchCellsByRowColumnOrNiner().ToList();
            foreach (var rule in _rules)
            {
                foreach (var nineCells in sequences)
                {
                    var hint = rule.HelpWith(nineCells);
                    if (hint != Hint.None)
                    {
                        _hintProviderEvent.Publish(hint);
                        return;
                    }    
                }
            }
            _hintProviderEvent.Publish(Hint.None);
        }
        
        ~Solver()
        {
            Console.WriteLine("aaah!");
        }
    }
}
