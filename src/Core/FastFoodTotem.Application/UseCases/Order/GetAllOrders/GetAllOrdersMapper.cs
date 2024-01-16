using AutoMapper;
using FastFoodTotem.Application.UseCases.Order.GetOrderById;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Order.GetAllOrders;

public class GetAllOrdersMapper : Profile
{
    public GetAllOrdersMapper()
    {
        CreateMap<OrderEntity, GetAllOrdersOrder>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => MapOrderedItems(src.OrderedItems)));
    }

    private IEnumerable<GetAllOrdersProductData> MapOrderedItems(IEnumerable<OrderedItemEntity> orderedItems)
    {
        return orderedItems.Select(item => new GetAllOrdersProductData
        {
            ProductId = item.ProductId,
            Name = item.Product.Name,
            Amount = item.Amount,
            Price = item.Product.Price
        });
    }
}
