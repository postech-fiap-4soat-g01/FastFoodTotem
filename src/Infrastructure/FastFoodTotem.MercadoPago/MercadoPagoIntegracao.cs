using FastFoodTotem.Domain.Contracts.Payments;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.MercadoPago.Dtos.Request;
using FastFoodTotem.MercadoPago.Dtos.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace FastFoodTotem.MercadoPago;

public class MercadoPagoPayment : IOrderPayment
{
    private readonly string _accessToken;
    private readonly string _baseUrl;
    private readonly string _userId;
    private readonly string _externalPosId;

    public MercadoPagoPayment(IConfiguration config)
    {
        _accessToken = config.GetSection("MercadoPago:AccessToken").Value ?? throw new ArgumentNullException("Null Access token");
        _baseUrl = config.GetSection("MercadoPago:BaseUrl").Value ?? throw new ArgumentNullException("Null Base Url");
        _userId = config.GetSection("MercadoPago:UserId").Value ?? throw new ArgumentNullException("Null User Id");
        _externalPosId = config.GetSection("MercadoPago:ExternalPosId").Value ?? throw new ArgumentNullException("Null External Pos Id");
    }

    public async Task<string> GerarQRCodeParaPagamentoDePedido(OrderEntity orderEntity)
    {
        var request = new GerarQRCodeRequest()
        {
            TotalAmount = orderEntity.GetTotal(),
            ExternalReference = orderEntity.Id.ToString(),
            Title = "Pedido Lanchonete",
            Description = "Pedido Lanchonete",
            NotificationUrl = $"https://webhook.d3fkon1.com/e8ff9837-9920-44c9-a0a1-434d2a02ea7c/order/{orderEntity.Id}?source_news=webhook",
            Items = orderEntity.OrderedItems.Select(item => new Item()
            {
                Title = item.Product.Name,
                UnitMeasure = "unit",
                Quantity = item.Amount,
                UnitPrice = item.Product.Price,
                TotalAmount = item.GetTotal(),
            }).ToList()
        };

        using (var httpRequest = new HttpClient())
        {
            httpRequest.BaseAddress = new Uri(_baseUrl);
            httpRequest.DefaultRequestHeaders.Clear();
            httpRequest.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var result = await httpRequest.PostAsync($"/instore/orders/qr/seller/collectors/{_userId}/pos/{_externalPosId}/qrs", content);

            if (result.IsSuccessStatusCode)
            {
                var resultString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GerarQRCodeResponse>(resultString).QrData;
            }

            return null;
        }
    }
}

