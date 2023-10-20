using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodTotem.Domain
{
    public static class Booststrap
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ICustomerService, CustomerService>();

            return services;
        }
    }
}
