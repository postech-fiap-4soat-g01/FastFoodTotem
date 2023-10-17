using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Domain.Entities
{
    public class CustomerEntity
    {
        public CustomerEntity(Guid id, string customerName, string customerEmail, string customerIdentification)
        {
            Id = id;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerIdentification = customerIdentification;
        }

        public Guid Id { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerEmail { get; private set; }
        public string CustomerIdentification { get; private set; }
    }
}
