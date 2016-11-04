using System;
using System.Windows.Controls;


namespace Northwind.UI.Common
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }


        private void LeftPane_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = (ViewModel)leftPane.SelectedItem;
            viewModel.RefreshAll();
        }
    }
}
