using FastFoodTotem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.Dtos.Responses.Order
{
    public class OrderGetAllResponseDto
    {
        public OrderGetAllResponseDto(IEnumerable<OrderGetByIdResponseDto> orders)
        {
            Orders = orders;
        }

        public IEnumerable<OrderGetByIdResponseDto> Orders { get; set; }
    }
}
