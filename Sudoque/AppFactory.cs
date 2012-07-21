using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Sudoque.Game;

namespace Sudoque
{
    public class AppFactory
    {
        public IUnityContainer CreateContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterInstance(typeof(IEventAggregator), new EventAggregator());
            container.RegisterType(typeof(ICreateCellViewModels), typeof(CellViewModelFactory));
            container.RegisterType(typeof(ICreateNinerViewModels), typeof(NinerViewModelFactory));
            
            return container;
        }
    }
}