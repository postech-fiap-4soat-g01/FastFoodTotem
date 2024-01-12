namespace FastFoodTotem.Application.UseCases.Customer.GetCustomers
{
    public sealed record GetCustomersResponse
    {
        public IEnumerable<Customers> Customers { get; set; }
    }

    public record Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }
    }
}
