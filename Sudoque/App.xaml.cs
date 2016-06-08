using System.Windows;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Sudoque.Behavior.Game.Engine.Rules;
using Sudoque.Game;
using Sudoque.Game.Engine;
using Sudoque.Game.Engine.Rules;
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
            var eventAggregator = new EventAggregator();
            var cellRepository = new CellRepository();
            var cellViewModelFactory = new CellViewModelFactory(eventAggregator, cellRepository);

            var ninerViewModelFactory = new NinerViewModelFactory(cellViewModelFactory);
            var puzzleViewModel = new PuzzleViewModel(ninerViewModelFactory, eventAggregator);
            var rules = new IMightBeAbleToHelp[]
                            {
                                new ActualsCollide(),
                                new OnlyOneSpace(),
                                new OnlyOnePotential(),
                                new PotentialsMatchAnActual(),
                            };
            new Solver(eventAggregator, cellRepository, rules);
            var window = new MainWindow(puzzleViewModel);
            window.Show();
        }
    }
}
