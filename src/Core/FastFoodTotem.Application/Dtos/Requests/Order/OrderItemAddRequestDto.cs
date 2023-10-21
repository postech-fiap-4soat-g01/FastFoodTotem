using FastFoodTotem.Application.DtoValidators;

namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public class OrderItemAddRequestDto : ApiBaseRequest
    {
        [GuidNotEmpty(ErrorMessage = "Invalid product Id!")]
        public Guid Id { get; set; }
    }
}
