using AutoMapper;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Order.UpdateOrder;

public class UpdateOrderMapper : Profile
{
    public UpdateOrderMapper()
    {
        CreateMap<UpdateOrderRequest, OrderEntity>();
        CreateMap<OrderEntity, UpdateOrderResponse>();
    }
}
