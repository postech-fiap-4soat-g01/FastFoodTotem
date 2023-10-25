using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {

        }

        public Task<OrderEntity> CreateAsync(OrderEntity orderCreateRequestDto, CancellationToken cancellationToken)
        => Task.FromResult(new OrderEntity());
    }
}
