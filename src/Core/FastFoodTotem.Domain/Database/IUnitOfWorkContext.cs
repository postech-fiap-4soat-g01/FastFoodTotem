using FastFoodTotem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFoodTotem.Domain.Database
{
    public interface IUnitOfWorkContext
    {
        int SaveChanges();
        DbSet<OrderEntity> Orders { get; }
        DbSet<ProductEntity> Products { get; }

    }
}
