namespace FastFoodTotem.Application.Dtos.Responses.Product
{
    public class ProductEditResponseDto : ApiBaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
