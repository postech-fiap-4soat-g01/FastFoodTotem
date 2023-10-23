using FastFoodTotem.Application.DtoValidators;

namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public class OrderItemAddRequestDto : ApiBaseRequest
    {
        public Guid OrderItemId { get; set; }
    }
}
