using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderByStatus;

public sealed record GetOrderByStatusResponse
{
    public GetOrderByStatusResponse(IEnumerable<GetOrderByStatusOrder> orders)
    {
        Orders = orders;
    }

    public IEnumerable<GetOrderByStatusOrder> Orders { get; set; }
}

public sealed record GetOrderByStatusOrder
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public IEnumerable<GetOrderByStatusProductData> Items { get; set; }
}

public sealed record GetOrderByStatusProductData
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
}
