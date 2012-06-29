using System.Windows;
using Sudoque.Game;

namespace Sudoque.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(PuzzleViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
