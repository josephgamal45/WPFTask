using InventoryWpf.Models;
using InventoryWpf.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryWpf.Views
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }


        private void Text_SearchChanged(object sender, TextChangedEventArgs e)
       {
            //var textBox = sender as TextBox;
            //string filter = textBox.Text.ToLower();
            //var items = new MainViewModel();
            //// Assuming `items` is your MainViewModel instance
            //var filteredItems = items.Items.Where(i =>
            //    i.Name.ToLower().Contains(filter) ||
            //    i.Category.ToLower().Contains(filter)).ToList();

            //// Update the ObservableCollection with the filtered items
            //items.Items.Clear();
            //foreach (var item in filteredItems)
            //{
            //    items.Items.Add(item);
            //}
            var textBox = sender as TextBox;
            _viewModel.FilterItems(textBox.Text);
            //DataContext = items.Items;
        }
    }
}