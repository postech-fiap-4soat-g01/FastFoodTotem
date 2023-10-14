using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Domain.Entities
{
    public class CategoryEntity
    {
        public CategoryEntity(Guid id, string name, CategoryType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public CategoryType Type { get; private set; }
    }
}
