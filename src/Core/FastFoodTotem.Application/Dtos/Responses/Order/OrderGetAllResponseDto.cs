namespace FastFoodTotem.Application.Dtos.Responses.Order
{
    public class OrderGetAllResponseDto
    {
        public OrderGetAllResponseDto(IEnumerable<OrderGetByIdResponseDto> orders)
        {
            Orders = orders;
        }

        public IEnumerable<OrderGetByIdResponseDto> Orders { get; set; }
    }
}
