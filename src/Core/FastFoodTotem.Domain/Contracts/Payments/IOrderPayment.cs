namespace FastFoodTotem.Domain.Contracts.Payments
{
    public interface IOrderPayment
    {
        Task<string> GerarQRCodeParaPagamentoDePedido();
    }
}
