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
            Name = customerCreateRequestDto.Name;
            Email = customerCreateRequestDto.Email;
            Identification = customerCreateRequestDto.Identification;
        }

        [Key]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Identification { get; private set; }
    }
}
