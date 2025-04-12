using Microsoft.EntityFrameworkCore;
using InventoryWpf.Models;

namespace InventoryWpf.Services
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=WPFTask;User Id=sa;Password=P@ssw0rd;Trusted_Connection=True;");
        }
    }
}