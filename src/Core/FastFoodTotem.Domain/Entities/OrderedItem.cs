using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class OrderedItemEntity
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }

        public ProductEntity Product { get; set; }
        public OrderEntity Order { get; set; }

        public decimal GetTotal()
        => Amount * Product.Price;
    }
}
