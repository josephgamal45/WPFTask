using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using InventoryWpf.Commands;
using InventoryWpf.Models;
using InventoryWpf.Services;
using InventoryWpf.ViewModels;
using InventoryWpf.Views;

namespace InventoryWpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private InventoryItem _selectedItem;
        public ObservableCollection<InventoryItem> Items { get; set; } = new ObservableCollection<InventoryItem>();
        public InventoryItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                ((RelayCommand)OpenEditItemCommand).RaiseCanExecuteChanged();
                ((RelayCommand)OpenDetailsCommand).RaiseCanExecuteChanged();
            }
        }
        InventoryDbContext dbContext = new InventoryDbContext();
        public ICommand OpenAddItemCommand { get; }
        public ICommand OpenEditItemCommand { get; }
        public ICommand OpenDetailsCommand { get; }

        public MainViewModel()
        {
            OpenAddItemCommand = new RelayCommand(OpenAddItem);
            OpenEditItemCommand = new RelayCommand(OpenEditItem, () => SelectedItem != null);
            OpenDetailsCommand = new RelayCommand(OpenDetails, () => SelectedItem != null);
            LoadData();
            // Sample data

        }
        public void FilterItems(string query)
        {
            var lowerQuery = query.ToLower();

            var filtered = dbContext.InventoryItems
                .Where(i => i.Name.ToLower().Contains(lowerQuery) || i.Category.ToLower().Contains(lowerQuery))
                .ToList();

            Items.Clear();
            foreach (var item in filtered)
            {
                Items.Add(item);
            }
        }
        private void OpenAddItem()
        {
            var vm = new AddEditItemViewModel();
            var window = new AddEditItemWindow { DataContext = vm };
            vm.SaveRequested += (item) =>
            {
                Items.Add(item);
                dbContext.InventoryItems.Add(item);
                dbContext.SaveChanges();
                window.Close();
                LoadData();
            };
            window.ShowDialog();
        }

        private void OpenEditItem()
        {
            if (SelectedItem == null) return;
            var vm = new AddEditItemViewModel(SelectedItem);
            var window = new AddEditItemWindow { DataContext = vm };
            vm.SaveRequested += (updatedItem) =>
            {
                SelectedItem.Name = updatedItem.Name;
                SelectedItem.Id = updatedItem.Id;

                SelectedItem.Category = updatedItem.Category;
                SelectedItem.StockQuantity = updatedItem.StockQuantity;
                SelectedItem.LastUpdated = updatedItem.LastUpdated;
                 
                window.Close();
                LoadData();
            };
            window.ShowDialog();
            LoadData();
        }

        private void OpenDetails()
        {
            if (SelectedItem == null) return;
            var window = new ViewItemDetailsWindow();
            window.DataContext = SelectedItem;
            window.ShowDialog();
        }

        private void LoadData()
        {
            Items.Clear();
            
            foreach (var item in dbContext.InventoryItems.ToList())
                Items.Add(item);
        }
    }
}
