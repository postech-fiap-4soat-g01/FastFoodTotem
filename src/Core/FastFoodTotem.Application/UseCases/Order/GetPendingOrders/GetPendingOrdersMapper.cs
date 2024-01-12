using AutoMapper;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Order.GetPendingOrders;

public class GetPendingOrdersMapper : Profile
{
    public GetPendingOrdersMapper()
    {
        CreateMap<OrderEntity, GetPendingOrdersOrder>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => MapOrderedItems(src.OrderedItems)));
    }

    private IEnumerable<GetPendingOrdersProductData> MapOrderedItems(IEnumerable<OrderedItemEntity> orderedItems)
    {
        return orderedItems.Select(item => new GetPendingOrdersProductData
        {
            ProductId = item.ProductId,
            Name = item.Product.Name,
            Amount = item.Amount,
            Price = item.Product.Price
        });
    }
}
