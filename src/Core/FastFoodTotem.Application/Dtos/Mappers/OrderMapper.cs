using AutoMapper;
using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.Dtos.Mappers;

public class OrderMapper : Profile
{
    public OrderMapper()
    {
        CreateMap<OrderCreateRequestDto, OrderEntity> ();
    }
}

