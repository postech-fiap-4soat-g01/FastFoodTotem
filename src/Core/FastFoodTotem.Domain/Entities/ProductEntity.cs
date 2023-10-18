namespace FastFoodTotem.Domain.Entities
{
    public class ProductEntity
    {
        protected ProductEntity() { }

        public ProductEntity(Guid id, Guid name, Guid categoryId, CategoryEntity category)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Category = category;
        }

        public Guid Id { get; private set; }
        public Guid Name { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
