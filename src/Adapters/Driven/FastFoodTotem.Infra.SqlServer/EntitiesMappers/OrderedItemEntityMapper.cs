using FastFoodTotem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFoodTotem.Infra.SqlServer.EntitiesMappers;

public class OrderedItemEntityMapper
{
    public static void ConfigureEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderedItemEntity>().ToTable("OrderedItem");

        modelBuilder.Entity<OrderedItemEntity>(x =>
        {
            x.ToTable("OrderedItem");
            x.HasKey(c => c.Id).HasName("OrderedItemId");
            x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            x.Property(c => c.ProductId).HasColumnName("ProductId");
            x.Property(c => c.OrderId).HasColumnName("OrderId");

            x.HasOne(c => c.Order)
            .WithMany(u => u.OrderedItems)
            .HasForeignKey(u => u.OrderId);

            x.HasOne(c => c.Product)
            .WithMany(u => u.OrderedItems)
            .HasForeignKey(u => u.ProductId);
        });
    }
}

