using FastFoodTotem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class OrderEntity
    {
        public OrderEntity() { }

        [Key]
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public OrderStatus Status { get; private set; }

        public IEnumerable<OrderedItemEntity> OrderedItems { get; private set; } = Enumerable.Empty<OrderedItemEntity>();
        public CustomerEntity Customer { get; set; }
    }
}
