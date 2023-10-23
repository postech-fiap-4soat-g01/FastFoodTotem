namespace FastFoodTotem.Domain.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        public IEnumerable<OrderedItemEntity> OrderedItems { get; set; } = Enumerable.Empty<OrderedItemEntity>();
    }
}
