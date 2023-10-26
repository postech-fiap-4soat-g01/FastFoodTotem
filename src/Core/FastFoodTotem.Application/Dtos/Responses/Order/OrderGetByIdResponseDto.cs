using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.Dtos.Responses.Order
{
    public class OrderGetByIdResponseDto
    {
        public OrderGetByIdResponseDto(int id, OrderStatus status, IEnumerable<OrderItemGetByIdResponseDto> items)
        {
            Id = id;
            Status = status;
            Items = items;
        }

        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderItemGetByIdResponseDto> Items { get; set; }
    }
}
