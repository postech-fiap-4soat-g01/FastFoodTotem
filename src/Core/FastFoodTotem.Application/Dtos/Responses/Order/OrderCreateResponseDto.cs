using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Responses.Order
{
    public class OrderCreateResponseDto
    {
        public int Id { get; set; }
        public string PaymentQrCode { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
