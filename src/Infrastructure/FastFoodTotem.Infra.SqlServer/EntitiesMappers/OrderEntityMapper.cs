using FastFoodTotem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFoodTotem.Infra.SqlServer.EntitiesMappers;

public class OrderEntityMapper
{
    public static void ConfigureEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderEntity>().ToTable("Order");

        modelBuilder.Entity<OrderEntity>(x =>
        {
            x.ToTable("Order");
            x.HasKey(c => c.Id).HasName("OrderId");
            x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            x.Property(c => c.CustomerId).HasDefaultValue(null).HasColumnName("CustomerId").IsRequired(false);
            x.Property(c => c.CreationDate).HasColumnName("CreationDate");
            x.Property(c => c.Status).HasColumnName("Status");

            x.HasMany(c => c.OrderedItems)
            .WithOne(u => u.Order)
            .HasForeignKey(y => y.OrderId);

            x.HasOne(c => c.Customer)
            .WithMany(u => u.Orders)
            .HasForeignKey(u => u.CustomerId);
        });
    }
}

