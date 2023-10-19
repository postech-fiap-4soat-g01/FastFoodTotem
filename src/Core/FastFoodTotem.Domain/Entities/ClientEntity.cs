using System.ComponentModel.DataAnnotations;

namespace FastFoodTotem.Domain.Entities
{
    public class ClientEntity
    {
        protected ClientEntity() { }

        [Key]
        public Guid Id { get; private set; }
    }
}
