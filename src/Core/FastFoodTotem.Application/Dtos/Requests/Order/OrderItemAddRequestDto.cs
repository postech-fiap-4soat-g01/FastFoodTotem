namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public class OrderItemAddRequestDto : ApiBaseRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
