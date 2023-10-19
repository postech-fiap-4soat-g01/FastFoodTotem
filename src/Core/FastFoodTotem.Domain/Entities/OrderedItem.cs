using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class OrderedItemEntity
    {
        protected OrderedItemEntity() { }

        [Key]
        public Guid Id { get; set; }

        public ProductEntity Product { get; private set; }
        public Guid ProductId { get; private set; }
        public OrderEntity Order { get; private set; }
        public Guid OrderId { get; private set; }
        public int Amount { get; private set; }
    }
}
