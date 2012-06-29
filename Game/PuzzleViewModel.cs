using System.Collections.Generic;

namespace Sudoque.Game
{
    public class PuzzleViewModel
    {
        public List<List<NinerViewModel>> Niners
        {
            get
            {
               return new List<List<NinerViewModel>> {
                   new List<NinerViewModel>{
                        new NinerViewModel(),
                        new NinerViewModel(),
                        new NinerViewModel(),
                    },
                    new List<NinerViewModel>{
                        new NinerViewModel(),
                        new NinerViewModel(),
                        new NinerViewModel(),
                    },
                    new List<NinerViewModel>{
                        new NinerViewModel(),
                        new NinerViewModel(),
                        new NinerViewModel(),
                    }
                };
            }
        }
    }
}