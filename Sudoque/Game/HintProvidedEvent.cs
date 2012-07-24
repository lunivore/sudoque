using Microsoft.Practices.Prism.Events;
using Sudoque.Game.Engine;
using System.Collections.Generic;

namespace Sudoque.Game
{
    public class HintProvidedEvent : CompositePresentationEvent<ICollection<Cell>>
    {
    }
}   