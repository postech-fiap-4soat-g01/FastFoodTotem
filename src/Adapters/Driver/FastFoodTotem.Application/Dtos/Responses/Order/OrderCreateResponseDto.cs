namespace FastFoodTotem.Application.Dtos.Responses
{
    public class OrderCreateResponseDto : ApiBaseResponse
    {
        public OrderCreateResponseDto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
