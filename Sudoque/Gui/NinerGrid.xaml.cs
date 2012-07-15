using System.Windows;
using System.Windows.Controls;

namespace Sudoque.Gui
{
    /// <summary>
    /// Interaction logic for NinerGrid.xaml
    /// </summary>
    public partial class NinerGrid : UserControl
    {
        public NinerGrid()
        {
            InitializeComponent();
        }

        private void OnFocusLost(object sender, RoutedEventArgs e)
        {
            ((ListBox)sender).SelectedItems.Clear();
        }
    }
}
