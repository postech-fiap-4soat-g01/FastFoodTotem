using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class CustomerEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }

        public IEnumerable<OrderEntity> Orders { get; set; } = Enumerable.Empty<OrderEntity>();
    }
}
