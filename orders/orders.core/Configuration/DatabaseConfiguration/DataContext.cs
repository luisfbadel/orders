using Microsoft.EntityFrameworkCore;
using orders.core.Configuration.DatabaseConfiguration.Mapping;
using orders.core.Models;

namespace orders.core.Configuration.DatabaseConfiguration
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderMap());
        }
    }
}
