using FastFoodTotem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class CategoryEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }

        public IEnumerable<ProductEntity> Products { get; set; } = Enumerable.Empty<ProductEntity>();
    }
}
