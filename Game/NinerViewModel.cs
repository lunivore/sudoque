using System.Collections.Generic;

namespace Sudoque.Game
{
    public class NinerViewModel
    {
        public List<List<CellViewModel>> Cells
        {
            get
            {
                return new List<List<CellViewModel>>
                           {
                               new List<CellViewModel>{
                                   new CellViewModel(), 
                                   new CellViewModel(), 
                                   new CellViewModel(), 
                               },
                               new List<CellViewModel>{
                                   new CellViewModel(), 
                                   new CellViewModel(), 
                                   new CellViewModel(), 
                               },
                               new List<CellViewModel>{
                                   new CellViewModel(), 
                                   new CellViewModel(), 
                                   new CellViewModel(), 
                               }
                           };
            }
        }
    }
}