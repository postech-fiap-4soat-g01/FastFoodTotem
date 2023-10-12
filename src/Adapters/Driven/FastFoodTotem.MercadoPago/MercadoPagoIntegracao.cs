using FastFoodTotem.Domain.Contracts.Payments;
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

    public async Task<string> GerarQRCodeParaPagamentoDePedido()
    {
        var request = new GerarQRCodeRequest()
        {
            TotalAmount = 12,
            ExternalReference = "pedido1",
            Title = "Pedido1",
            Description = "Pedido1",
            Items = new List<Item>()
            {
                new Item()
                {
                    Title = "Hamburguer",
                    UnitMeasure = "unit",
                    Quantity = 1,
                    UnitPrice = 12,
                    TotalAmount = 12,
                }
            }
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

