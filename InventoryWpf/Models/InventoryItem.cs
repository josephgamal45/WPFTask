using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryWpf.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a positive number")]
        public int StockQuantity { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}