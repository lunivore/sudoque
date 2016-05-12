using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Sudoque.Game;
using Sudoque.Game.Engine;
using Sudoque.Game.Engine.Rules;

namespace Sudoque
{
    public class AppFactory
    {
        public IUnityContainer CreateContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterInstance(typeof(IEventAggregator), new EventAggregator());
            container.RegisterInstance(typeof (ILookAfterCells), new CellRepository());
            container.RegisterType(typeof(ICreateCellViewModels), typeof(CellViewModelFactory));
            container.RegisterType(typeof(ICreateNinerViewModels), typeof(NinerViewModelFactory));            
            container.RegisterInstance(typeof (PuzzleViewModel), container.Resolve<PuzzleViewModel>());

            container.RegisterInstance(typeof(IEnumerable<IMightBeAbleToHelp>), 
                new IMightBeAbleToHelp[]
                {
                    new ActualsCollide(),
                    new OnlyOneSpace(),
                    new OnlyOnePotential(), 
                    
                });
            container.RegisterInstance(typeof (Solver), container.Resolve<Solver>());
            
            return container;
        }
    }
}