namespace FastFoodTotem.Application.Dtos.Responses.Customer
{
    public class CustomerGetByCPFResponseDto : ApiBaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
