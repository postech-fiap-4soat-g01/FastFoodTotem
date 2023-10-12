using System.Text.Json.Serialization;

namespace FastFoodTotem.MercadoPago.Dtos.Response;

public class GerarQRCodeResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("point_of_interaction")]
    public PointOfInteraction PointOfInteraction {  get; set; }
}

public class PointOfInteraction
{
    public string Type { get; set; }
    public string SubType { get; set; }
    public ApplicationData ApplicationData { get; set; }
    public TransactionData TransactionData { get; set; }
}

public class ApplicationData
{
    public string Name { get; set; }
    public string Version { get; set; }
}

public class TransactionData
{
    public string QrCodeBase64 { get; set; }
    public string QrCode { get; set; }
    public string TicketUrl { get; set; }
}
