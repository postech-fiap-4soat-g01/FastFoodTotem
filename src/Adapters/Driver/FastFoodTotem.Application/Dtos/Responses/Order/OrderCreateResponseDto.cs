namespace FastFoodTotem.Application.Dtos.Responses
{
    public struct OrderCreateResponseDto
    {
        public OrderCreateResponseDto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
