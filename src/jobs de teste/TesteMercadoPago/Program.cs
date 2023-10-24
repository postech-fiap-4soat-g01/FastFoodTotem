using FastFoodTotem.Domain.Contracts.Payments;
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

var qr = await mercadoPago.GerarQRCodeParaPagamentoDePedido();


Console.WriteLine(qr);