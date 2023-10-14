using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Domain.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public OrderStatus Status { get; private set; }
        public IEnumerable<ProductEntity> Products { get; private set; } = Enumerable.Empty<ProductEntity>();
    }
}
