using FastFoodTotem.Domain.Contracts.Payments;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.MercadoPago;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddScoped<IOrderPayment, MercadoPagoPayment>();
        });

var host = CreateHostBuilder(args).Build();


var mercadoPago = host.Services.GetRequiredService<IOrderPayment>();

var order = new OrderEntity()
{
    Status = FastFoodTotem.Domain.Enums.OrderStatus.Received,
    CustomerId = 1,
    Id = 2,
    OrderedItems = new List<OrderedItemEntity>()
    {
        new OrderedItemEntity()
        {
            Id = 3,
            Amount = 2,
            Product = new ProductEntity()
            {
                Id = 4,
                Name = "Name",
                Price = 9.99M
            }
        }
    }
};

var qr = await mercadoPago.GerarQRCodeParaPagamentoDePedido(order);


Console.WriteLine(qr);