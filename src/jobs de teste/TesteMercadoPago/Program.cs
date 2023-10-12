using FastFoodTotem.MercadoPago;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");
IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddScoped<MercadoPagoIntegracao>();
        });

var host = CreateHostBuilder(args).Build();


var mercadoPago = host.Services.GetRequiredService<MercadoPagoIntegracao>();

var payment = await mercadoPago.CriarPagamentoQRCode();