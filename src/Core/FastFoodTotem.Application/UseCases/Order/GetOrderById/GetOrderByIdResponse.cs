using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderById;

public sealed record GetOrderByIdResponse
{
    public GetOrderByIdResponse()
    {

    }

    public GetOrderByIdResponse(int id, OrderStatus status, IEnumerable<GetOrderByIdProductData> items)
    {
        Id = id;
        Status = status;
        Items = items;
    }

    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public IEnumerable<GetOrderByIdProductData> Items { get; set; }
}

public sealed record GetOrderByIdProductData
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
}
