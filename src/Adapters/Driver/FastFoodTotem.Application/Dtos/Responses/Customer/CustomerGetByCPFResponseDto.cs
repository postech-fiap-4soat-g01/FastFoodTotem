namespace FastFoodTotem.Application.Dtos.Responses.Customer
{
    public struct CustomerGetByCPFResponseDto
    {
        public CustomerGetByCPFResponseDto(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
