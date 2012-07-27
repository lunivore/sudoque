using System.Collections.Generic;

namespace Sudoque.Game.Engine
{
    public interface IMightBeAbleToHelp
    {
        Hint HelpWith(IEnumerable<Cell> isAny);
    }
}
