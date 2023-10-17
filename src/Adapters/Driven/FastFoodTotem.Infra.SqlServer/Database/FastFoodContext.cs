using FastFoodTotem.Domain.Database;
using FastFoodTotem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFoodTotem.Infra.SqlServer.Database
{
    public class FastFoodContext: DbContext, IUnitOfWorkContext
    {
        public FastFoodContext(DbContextOptions<FastFoodContext> options)
           : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
