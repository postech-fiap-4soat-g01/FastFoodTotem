namespace FastFoodTotem.Application.Dtos.Responses.Customer
{
    public struct CustomerGetResponseDto
    {
        public CustomerGetResponseDto(Guid id, string name, string email, string identification)
        {
            Id = id;
            Name = name;
            Email = email;
            Identification = identification;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Identification { get; private set; }
    }
}
