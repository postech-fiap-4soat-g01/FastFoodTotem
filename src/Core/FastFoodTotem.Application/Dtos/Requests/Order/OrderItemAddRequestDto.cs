namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public class OrderItemAddRequestDto : ApiBaseRequest
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
