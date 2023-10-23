using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class OrderedItemEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Amount { get; set; }

        public ProductEntity Product { get; set; }
        public OrderEntity Order { get; set; }
    }
}
