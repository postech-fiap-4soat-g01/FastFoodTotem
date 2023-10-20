namespace FastFoodTotem.Application.Dtos.Responses.Customer
{
    public struct CustomerGetByCPFResponseDto
    {
        public CustomerGetByCPFResponseDto(Guid id, string customerName, string customerEmail)
        {
            Id = id;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
        }

        public Guid Id { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerEmail { get; private set; }
    }
}
