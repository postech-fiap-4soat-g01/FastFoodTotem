using System.Text.Json.Serialization;

namespace FastFoodTotem.MercadoPago.Dtos.Request;

public class GerarQRCodeRequest
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("installments")]
    public int Installments { get; set; }

    [JsonPropertyName("issuer_id")]
    public string IssuerId { get; set; }

    [JsonPropertyName("payer")]
    public Payer Payer { get; set; }

    [JsonPropertyName("payment_method_id")]
    public string PaymentMethodId { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }

    [JsonPropertyName("transaction_amount")]
    public decimal TransactionAmount { get; set; }
}

public class Payer
{

}
