using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.UseCases.Customer.GetCustomerByCpf;

public sealed record GetCustomerByCpfResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
