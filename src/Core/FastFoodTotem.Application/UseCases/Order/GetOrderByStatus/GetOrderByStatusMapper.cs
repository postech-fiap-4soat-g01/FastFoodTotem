using AutoMapper;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderByStatus;

public class GetOrderByStatusMapper : Profile
{
    public GetOrderByStatusMapper()
    {
        CreateMap<OrderEntity, GetOrderByStatusOrder>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => MapOrderedItems(src.OrderedItems)));
    }

    private IEnumerable<GetOrderByStatusProductData> MapOrderedItems(IEnumerable<OrderedItemEntity> orderedItems)
    {
        return orderedItems.Select(item => new GetOrderByStatusProductData
        {
            ProductId = item.ProductId,
            Name = item.Product.Name,
            Amount = item.Amount,
            Price = item.Product.Price
        });
    }
}
