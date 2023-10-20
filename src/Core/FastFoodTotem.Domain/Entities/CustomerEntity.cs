using FastFoodTotem.Application.Dtos.Requests.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Domain.Entities
{
    public class CustomerEntity
    {
        protected CustomerEntity() { }

        public CustomerEntity(CustomerCreateRequestDto customerCreateRequestDto) 
        { 
            Id = Guid.NewGuid();
            CustomerName = customerCreateRequestDto.CustomerName;
            CustomerEmail = customerCreateRequestDto.CustomerEmail;
            CustomerIdentification = customerCreateRequestDto.CustomerIdentification;
        }

        [Key]
        public Guid Id { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerEmail { get; private set; }
        public string CustomerIdentification { get; private set; }
    }
}
