using FastFoodTotem.Application.ApplicationServices;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Services;
using FastFoodTotem.Infra.SqlServer.Database;
using FastFoodTotem.Infra.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodTotem.Infra.IoC;

public static class DependencyInjection
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureRepositories(services);
        ConfigureDatabase(services, configuration);
        ConfigureServices(services);
        ConfigureApplicationServices(services);
    }

    private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FastFoodContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
    }

    private static void ConfigureRepositories(IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IOrderService, OrderService>();
        services.AddSingleton<ICategoryService, CategoryService>();
        services.AddSingleton<IProductService, ProductService>();
        services.AddTransient<ICustomerService, CustomerService>();
    }

    private static void ConfigureApplicationServices(IServiceCollection services)
    {
        services.AddSingleton<ICustomerApplicationService, CustomerApplicationService>();
        services.AddSingleton<ICategoryApplicationService, CategoryApplicationService>();
        services.AddSingleton<IOrderApplicationService, OrderApplicationService>();
        services.AddSingleton<IProductApplicationService, ProductApplicationService>();
    }
}

