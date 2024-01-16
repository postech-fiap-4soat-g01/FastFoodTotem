using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.GetPendingOrders;

public sealed record GetPendingOrdersResponse
{
    public GetPendingOrdersResponse(IEnumerable<GetPendingOrdersOrder> orders)
    {
        Orders = orders;
    }

    public IEnumerable<GetPendingOrdersOrder> Orders { get; set; }
}

public sealed record GetPendingOrdersOrder
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public IEnumerable<GetPendingOrdersProductData> Items { get; set; }
}

public sealed record GetPendingOrdersProductData
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
}
