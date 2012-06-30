using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Sudoque.Game;
using Sudoque.Gui;

namespace Sudoque
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType(typeof (PuzzleViewModel));
            container.RegisterType(typeof (NinerViewModel));
            container.RegisterInstance(typeof(IEventAggregator), new EventAggregator());
            container.RegisterType(typeof(ICreateCells), typeof (CellFactory));
            container.RegisterType(typeof(ICreateNiners), typeof (NinerFactory));
            
            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}
