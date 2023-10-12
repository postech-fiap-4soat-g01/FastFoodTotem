using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.Extensions.Configuration;

namespace FastFoodTotem.MercadoPago;

public class MercadoPagoIntegracao
{
    private readonly string _accessToken;
    private readonly string _payerType;
    private readonly string _payerEmail;
    private readonly string _paymentType;

    public MercadoPagoIntegracao(IConfiguration config)
    {
        _accessToken = config.GetSection("MercadoPago:AccessToken").Value;
        _payerType = config.GetSection("MercadoPago:TipoPagador").Value;
        _payerEmail = config.GetSection("MercadoPago:EmailPagador").Value;
        _paymentType = config.GetSection("MercadoPago:TipoPagamento").Value;
    }

    public async Task<Payment> CriarPagamentoQRCode()
    {
        MercadoPagoConfig.AccessToken = _accessToken;

        var request = new PaymentCreateRequest
        {
            Description = "Teste",
            Installments = 1,
            Payer = new PaymentPayerRequest
            {
                Type = _payerType,
                Email = _payerEmail,
            },
            PaymentMethodId = _paymentType,
            TransactionAmount = 100,
        };

        var client = new PaymentClient();
        request.PaymentMethodId = "Debin_transfer";
        Payment payment = await client.CreateAsync(request);

        return payment;
    }
}

