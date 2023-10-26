using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public class OrderCreateRequestDto : ApiBaseRequest
    {
        public CustomerEntity Customer { get; set; }
        public IList<OrderItemAddRequestDto> Items { get; set; }
    }
}
