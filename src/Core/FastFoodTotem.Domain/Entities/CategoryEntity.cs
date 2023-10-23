using FastFoodTotem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class CategoryEntity
    {
        protected CategoryEntity() { }

        public CategoryEntity(Guid id, string name, CategoryType type) : this() 
        {
            Id = id;
            Name = name;
            Type = type;
        }

        [Key]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public CategoryType Type { get; private set; }

        public IEnumerable<ProductEntity> Products { get; private set; } = Enumerable.Empty<ProductEntity>();
    }
}
