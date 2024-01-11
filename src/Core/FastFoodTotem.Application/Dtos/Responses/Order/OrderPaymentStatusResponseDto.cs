using FastFoodTotem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.Dtos.Responses.Order
{
    public class OrderPaymentStatusResponseDto
    {
        public OrderPaymentStatusResponseDto(int id, OrderStatus status, IEnumerable<OrderItemResponseDto> items)
        {
            Id = id;
            Status = status.Equals(OrderStatus.AwaitingPayment) ? PaymentStatus.AwaitingPayment : PaymentStatus.PaymentConfirmed;
            Items = items;
        }

        public int Id { get; set; }
        public PaymentStatus Status { get; set; }
        public IEnumerable<OrderItemResponseDto> Items { get; set; }
    }
}
