using FastFoodTotem.Domain.Database;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Infra.SqlServer.EntitiesMappers;
using Microsoft.EntityFrameworkCore;

namespace FastFoodTotem.Infra.SqlServer.Database
{
    public class FastFoodContext : DbContext, IUnitOfWorkContext
    {
        public FastFoodContext(DbContextOptions<FastFoodContext> options)
           : base(options)
        {
        }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderedItemEntity> OrderedItems { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.HasDefaultSchema("FastFoodTotem");

            MapEntities(modelBuilder);
        }

        private void MapEntities(ModelBuilder modelBuilder)
        {
            CustomerEntityMapper.ConfigureEntity(modelBuilder);
            OrderedItemEntityMapper.ConfigureEntity(modelBuilder);
            OrderEntityMapper.ConfigureEntity(modelBuilder);
            ProductEntityMapper.ConfigureEntity(modelBuilder);
        }
    }
}
