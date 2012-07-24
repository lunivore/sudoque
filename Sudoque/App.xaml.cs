using System.Windows;
using Microsoft.Practices.Unity;
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
            var container = new AppFactory().CreateContainer();
            
            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}
