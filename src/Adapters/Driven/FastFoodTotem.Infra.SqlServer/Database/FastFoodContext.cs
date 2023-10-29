using FastFoodTotem.Domain.Database;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;
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
            SeedData(modelBuilder);
        }

        private void MapEntities(ModelBuilder modelBuilder)
        {
            CustomerEntityMapper.ConfigureEntity(modelBuilder);
            OrderedItemEntityMapper.ConfigureEntity(modelBuilder);
            OrderEntityMapper.ConfigureEntity(modelBuilder);
            ProductEntityMapper.ConfigureEntity(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity() { Id = 1, Name = "Hamburguer", Type = CategoryType.Burguer, Price = (decimal)13.0 },
                new ProductEntity() { Id = 2, Name = "X-Burguer", Type = CategoryType.Burguer, Price = (decimal)20.0 },
                new ProductEntity() { Id = 3, Name = "X-Bacon", Type = CategoryType.Burguer, Price = (decimal)25.0 },
                new ProductEntity() { Id = 4, Name = "X-Frango", Type = CategoryType.Burguer, Price = (decimal)25.0 },
                new ProductEntity() { Id = 5, Name = "X-Salada", Type = CategoryType.Burguer, Price = (decimal)15.0 },

                new ProductEntity() { Id = 6, Name = "Batata Pequena", Type = CategoryType.Accompaniment, Price = (decimal)5.0 },
                new ProductEntity() { Id = 7, Name = "Batata Média", Type = CategoryType.Accompaniment, Price = (decimal)7.0 },
                new ProductEntity() { Id = 8, Name = "Batata Grande", Type = CategoryType.Accompaniment, Price = (decimal)9.0 },
                new ProductEntity() { Id = 9, Name = "Onion Ring Pequeno", Type = CategoryType.Accompaniment, Price = (decimal)5.0 },
                new ProductEntity() { Id = 10, Name = "Onion Ring Médio", Type = CategoryType.Accompaniment, Price = (decimal)7.0 },
                new ProductEntity() { Id = 11, Name = "Onion Ring Grande", Type = CategoryType.Accompaniment, Price = (decimal)9.0 },

                new ProductEntity() { Id = 12, Name = "Coca Cola Lata", Type = CategoryType.Drink, Price = (decimal)6.0 },
                new ProductEntity() { Id = 13, Name = "Fanta Laranja Lata", Type = CategoryType.Drink, Price = (decimal)6.0 },
                new ProductEntity() { Id = 14, Name = "Fanta Guaraná Lata", Type = CategoryType.Drink, Price = (decimal)6.0 },
                new ProductEntity() { Id = 15, Name = "Sprite Lata", Type = CategoryType.Drink, Price = (decimal)6.0 },
                new ProductEntity() { Id = 16, Name = "Fanta Uva Lata", Type = CategoryType.Drink, Price = (decimal)6.0 },

                new ProductEntity() { Id = 17, Name = "Picolé Chocolate", Type = CategoryType.Dessert, Price = (decimal)6.0 },
                new ProductEntity() { Id = 18, Name = "Sorvete Casquinha", Type = CategoryType.Dessert, Price = (decimal)3.0 },
                new ProductEntity() { Id = 19, Name = "Pudim", Type = CategoryType.Dessert, Price = (decimal)7.0 },
                new ProductEntity() { Id = 20, Name = "Mousse de Maracujá", Type = CategoryType.Dessert, Price = (decimal)10.50 },
                new ProductEntity() { Id = 21, Name = "Torta de Morango", Type = CategoryType.Dessert, Price = (decimal)13.0 }
            );

            modelBuilder.Entity<CustomerEntity>().HasData(
                new CustomerEntity() { Id = 1, Name = "João José", Email = "joao_joao@joao.com", Identification = "86617589041" },
                new CustomerEntity() { Id = 2, Name = "Maria José", Email = "maria_maria@maria.com", Identification = "56419341000" }
            );
        }

    }
}
