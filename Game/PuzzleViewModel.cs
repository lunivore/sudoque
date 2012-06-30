using System.Collections.Generic;
using System.Linq;

namespace Sudoque.Game
{
    public class PuzzleViewModel
    {
        private readonly ICreateNiners _ninerFactory;

        public PuzzleViewModel(ICreateNiners ninerFactory)
        {
            _ninerFactory = ninerFactory;
        }

        public IEnumerable<IEnumerable<NinerViewModel>> Niners
        {
            get
            {
               return new[]{0, 1, 2}.ToList().Select(row => 
                   new[]{0, 1, 2}.ToList().Select(column => 
                       _ninerFactory.Create(column, row)));
            }
        }
    }
}