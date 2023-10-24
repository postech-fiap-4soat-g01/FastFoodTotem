namespace FastFoodTotem.Domain.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        public IEnumerable<OrderedItemEntity> OrderedItems { get; set; } = Enumerable.Empty<OrderedItemEntity>();
    }
}
