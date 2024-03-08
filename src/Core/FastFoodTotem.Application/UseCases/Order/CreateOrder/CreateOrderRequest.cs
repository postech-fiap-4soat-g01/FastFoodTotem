using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.CreateOrder;

public class CreateOrderRequest : IRequest<CreateOrderResponse>
{
    public IList<OrderItens> OrderedItems { get; set; }
}

public sealed record OrderItens
{
    public int ProductId { get; set; }
    public int Amount { get; set; }
}
