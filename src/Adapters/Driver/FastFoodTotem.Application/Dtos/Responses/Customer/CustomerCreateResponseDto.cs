namespace FastFoodTotem.Application.Dtos.Responses.Customer
{
    public struct CustomerCreateResponseDto
    {
        public CustomerCreateResponseDto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
