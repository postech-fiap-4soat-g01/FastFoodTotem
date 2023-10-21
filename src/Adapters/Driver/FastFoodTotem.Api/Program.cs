using FastFoodTotem.Domain;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Infra.SqlServer.Repositories;
using System.Reflection;
using FastFoodTotem.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostContext, config) =>
{
    const string fileSettingsName = "appsettings";
    config
        .AddUserSecrets<Program>(optional: true)
        .AddJsonFile($"{fileSettingsName}.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"{fileSettingsName}.{hostContext.HostingEnvironment.EnvironmentName}.json")
        .AddEnvironmentVariables();
});

builder.Host.ConfigureLogging(logging =>
{
    logging
        .ClearProviders()
        .AddConsole();
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(setup =>
    {
        setup.SwaggerDoc("v1",
            new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Fast Food Totem Api",
                Version = "v1",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                {
                    //TODO - Add e-mail and name
                    Email = "",
                    Name = "",
                }
            });

        var filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
        setup.IncludeXmlComments(filePath);
    })
    .AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    })
    .AddHealthChecks();

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger().UseSwaggerUI();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    //TODO healthcheck

    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.MapControllerRoute(name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();