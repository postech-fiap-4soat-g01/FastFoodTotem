using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Infra.SqlServer.Database;
using FastFoodTotem.Infra.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodTotem.Infra.SqlServer.IoC
{
    public static class DependencyInjection
    {
        public static void AddConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FastFoodContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
        }

        public static void AddConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
