using FastFoodTotem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFoodTotem.Infra.SqlServer.EntitiesMappers;

public static class CategoryEntityMapper
{
    public static void ConfigureEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>().ToTable("Category");

        modelBuilder.Entity<CategoryEntity>(x =>
        {
            x.ToTable("Category");
            x.HasKey(c => c.Id).HasName("CategoryId");
            x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            x.Property(c => c.Name).HasColumnName("Name").HasMaxLength(255);
            x.Property(c => c.Type).HasColumnName("Type");
        });
    }
}

