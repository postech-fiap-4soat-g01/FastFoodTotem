using FastFoodTotem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFoodTotem.Infra.SqlServer.EntitiesMappers;

public class ProductEntityMapper
{
    public static void ConfigureEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>().ToTable("Product");

        modelBuilder.Entity<ProductEntity>(x =>
        {
            x.ToTable("Product");
            x.HasKey(c => c.Id).HasName("ProductId");
            x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            x.Property(c => c.Name).HasColumnName("Name").HasMaxLength(255);
            x.Property(c => c.Type).HasColumnName("Type");
            x.Property(c => c.Price).HasColumnName("Price").HasPrecision(18, 2);
            x.Property(c => c.Description).HasColumnName("Description");
            x.Property(c => c.ProductImageUrl).HasColumnName("ProductImageUrl");

            x.HasMany(y => y.OrderedItems)
            .WithOne(y => y.Product)
            .HasForeignKey(y => y.ProductId);
        });
    }
}

