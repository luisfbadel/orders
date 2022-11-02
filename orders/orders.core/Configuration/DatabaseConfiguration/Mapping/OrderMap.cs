
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orders.core.Models;

namespace orders.core.Configuration.DatabaseConfiguration.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders")
               .HasKey(c => c.Id);
        }
    }
}
