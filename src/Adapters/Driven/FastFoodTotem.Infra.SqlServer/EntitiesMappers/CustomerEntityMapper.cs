using FastFoodTotem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFoodTotem.Infra.SqlServer.EntitiesMappers;

public class CustomerEntityMapper
{
    public static void ConfigureEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerEntity>().ToTable("Customer");

        modelBuilder.Entity<CustomerEntity>(x =>
        {
            x.ToTable("Customer");
            x.HasKey(c => c.Id).HasName("CustomerId");
            x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            x.Property(c => c.Name).HasColumnName("Name").HasMaxLength(255);
            x.Property(c => c.Email).HasColumnName("Email").HasMaxLength(255);
            x.Property(c => c.Identification).HasColumnName("Identification");

            x.HasMany(y => y.Orders)
            .WithOne(y => y.Customer)
            .HasForeignKey(y => y.CustomerId);
        });
    }
}

