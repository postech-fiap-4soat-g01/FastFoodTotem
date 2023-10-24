using FastFoodTotem.Application.ApplicationServices;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Validators.Customer;
using FastFoodTotem.Application.Dtos.Validators.Order;
using FastFoodTotem.Application.Dtos.Validators.Product;
using FastFoodTotem.Domain.Contracts.Payments;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Services;
using FastFoodTotem.Domain.Validations;
using FastFoodTotem.Infra.SqlServer.Database;
using FastFoodTotem.Infra.SqlServer.Repositories;
using FastFoodTotem.MercadoPago;
using FluentValidation;
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
        ConfigureNotificationServices(services);
        ConfigureValidators(services);
        ConfigureOrderPaymentServices(services);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FastFoodContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"),
                                                     b => b.MigrationsAssembly("FastFoodTotem.Infra.SqlServer")));
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
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddTransient<ICustomerService, CustomerService>();
    }

    private static void ConfigureApplicationServices(IServiceCollection services)
    {
        services.AddScoped<ICustomerApplicationService, CustomerApplicationService>();
        services.AddScoped<ICategoryApplicationService, CategoryApplicationService>();
        services.AddScoped<IOrderApplicationService, OrderApplicationService>();
        services.AddScoped<IProductApplicationService, ProductApplicationService>();
    }

    private static void ConfigureNotificationServices(IServiceCollection services)
    {
        // Must be scoped
        services.AddScoped<IValidationNotifications, ValidationNotifications>();
    }

    private static void ConfigureValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<CustomerCreateRequestDto>, CustomerCreateRequestDtoValidator>();
        services.AddScoped<IValidator<ProductCreateRequestDto>, ProductCreateRequestDtoValidator>();
        services.AddScoped<IValidator<ProductEditRequestDto>, ProductEditRequestDtoValidator>();
        services.AddScoped<IValidator<OrderCreateRequestDto>, OrderCreateRequestDtoValidator>();
        services.AddScoped<IValidator<OrderItemAddRequestDto>, OrderItemAddRequestDtoValidator>();
    }

    private static void ConfigureOrderPaymentServices(IServiceCollection services)
    {
        services.AddScoped<IOrderPayment, MercadoPagoPayment>();
    }
}

