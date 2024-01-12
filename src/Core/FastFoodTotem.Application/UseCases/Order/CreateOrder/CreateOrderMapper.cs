using AutoMapper;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Order.CreateOrder;

public class CreateOrderMapper : Profile
{
    public CreateOrderMapper()
    {
        CreateMap<CreateOrderRequest, OrderEntity>();
        CreateMap<OrderEntity, CreateOrderResponse> ();
        CreateMap<OrderItens, OrderedItemEntity>();
    }
}
