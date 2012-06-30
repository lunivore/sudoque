﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
