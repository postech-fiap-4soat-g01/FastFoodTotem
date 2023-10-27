namespace FastFoodTotem.Application.Dtos.Responses.Customer;

public class CustomerGetResponseDto
{
    public IEnumerable<CustomerGetResponseData> Customers { get; set; }
}

public class CustomerGetResponseData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Identification { get; set; }
}

