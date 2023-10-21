using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class CustomerEntity
    {
        public CustomerEntity() 
        { 

        }

        [Key]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Identification { get; private set; }
    }
}
