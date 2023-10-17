namespace FastFoodTotem.Application.Dtos.Responses.Customer
{
    public struct CustomerGetResponseDto
    {
        public CustomerGetResponseDto(Guid id, string customerName, string customerEmail, string customerIdentification)
        {
            Id = id;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerIdentification = customerIdentification;
        }

        public Guid Id { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerEmail { get; private set; }
        public string CustomerIdentification { get; private set; }
    }
}
