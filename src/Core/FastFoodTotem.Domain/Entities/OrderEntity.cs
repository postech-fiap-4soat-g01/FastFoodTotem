using FastFoodTotem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }

        public IEnumerable<OrderedItemEntity> OrderedItems { get; set; } = Enumerable.Empty<OrderedItemEntity>();
        public CustomerEntity Customer { get; set; }
    }
}
