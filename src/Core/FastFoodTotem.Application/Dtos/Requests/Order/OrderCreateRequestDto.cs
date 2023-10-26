using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public class OrderCreateRequestDto : ApiBaseRequest
    {
        public int? CustomerId { get; set; }
        public IList<OrderItemAddRequestDto> OrderedItems { get; set; }
    }
}
