using Newtonsoft.Json;

namespace FastFoodTotem.MercadoPago.Dtos.Request;

public class GerarQRCodeRequest
{
    [JsonProperty("total_amount")]
    public decimal TotalAmount { get; set; }

    [JsonProperty("external_reference")]
    public string ExternalReference { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    [JsonProperty("notification_url")]
    public string NotificationUrl { get; set; }
}

public class Item
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("unit_measure")]
    public string UnitMeasure { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("unit_price")]
    public decimal UnitPrice { get; set; }

    [JsonProperty("total_amount")]
    public decimal TotalAmount { get; set; }
}

