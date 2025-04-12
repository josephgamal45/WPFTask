using InventoryWpf.Commands;
using InventoryWpf.Models;
using InventoryWpf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryWpf.ViewModels
{
    public class AddEditItemViewModel : ViewModelBase
    {
        public InventoryItem Item { get; set; }
        public bool IsEditMode { get; set; }
        InventoryDbContext dbContext = new InventoryDbContext();

        public ICommand SaveCommand { get; }

        public event Action<InventoryItem> SaveRequested;

        public AddEditItemViewModel(InventoryItem item = null)
        {
            Item = item != null ? new InventoryItem
            {
                Name = item.Name,
                Category = item.Category,
                StockQuantity = item.StockQuantity,
                LastUpdated = item.LastUpdated,
                Id=item.Id
            } : new InventoryItem();

            IsEditMode = item != null;
            SaveCommand = new RelayCommand(Save);
           
          
        }
     
        private void Save()
        {
            if(Item!=null)
            {
                var entity = dbContext.InventoryItems.Where(A => A.Id == Item.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = Item.Name;
                    entity.Category = Item.Category;
                    entity.StockQuantity = Item.StockQuantity;
                    entity.LastUpdated = Item.LastUpdated;
                    dbContext.InventoryItems.Update(entity);
                    dbContext.SaveChanges();
                }
            }
            Item.LastUpdated = DateTime.Now;
            SaveRequested?.Invoke(Item);
            
        }
    }
}
