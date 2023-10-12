using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FastFoodTotem.MercadoPago.Dtos.Response;

public class GerarQRCodeResponse
{
    [JsonProperty("qr_data")]
    public string QrData { get; set; }
}
