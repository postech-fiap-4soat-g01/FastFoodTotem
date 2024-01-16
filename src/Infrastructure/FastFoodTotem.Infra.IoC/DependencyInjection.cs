using FastFoodTotem.Application.MediatorPipes.Behavior;
using FastFoodTotem.Domain;
using FastFoodTotem.Domain.Contracts.Payments;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Validations;
using FastFoodTotem.Infra.SqlServer.Database;
using FastFoodTotem.Infra.SqlServer.Repositories;
using FastFoodTotem.MercadoPago;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FastFoodTotem.Infra.IoC;

public static class DependencyInjection
{
    private static string pathToApplicationAssembly = Path.Combine(AppContext.BaseDirectory, "FastFoodTotem.Application.dll");

    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureRepositories(services);
        ConfigureDatabase(services, configuration);
        ConfigureNotificationServices(services);
        ConfigureValidators(services);
        ConfigureOrderPaymentServices(services);
        ConfigureMediatr(services);
        ConfigureAutomapper(services);
    }

    private static void ConfigureAutomapper(IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.LoadFrom(pathToApplicationAssembly));
    }

    private static void ConfigureMediatr(IServiceCollection services)
    {
       

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.LoadFrom(pathToApplicationAssembly)));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FastFoodContext>(options => options.UseSqlServer(configuration.GetConnectionString(ConstantsEnv.CONNECTION_STRING),
                                                     b => b.MigrationsAssembly("FastFoodTotem.Infra.SqlServer")));
    }

    private static void ConfigureRepositories(IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }

    private static void ConfigureNotificationServices(IServiceCollection services)
    {
        // Must be scoped
        services.AddScoped<IValidationNotifications, ValidationNotifications>();
    }

    private static void ConfigureValidators(IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.LoadFrom(pathToApplicationAssembly));
    }

    private static void ConfigureOrderPaymentServices(IServiceCollection services)
    {
        services.AddScoped<IOrderPayment, MercadoPagoPayment>();
    }
}

