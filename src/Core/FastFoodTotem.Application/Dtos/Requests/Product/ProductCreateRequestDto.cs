namespace FastFoodTotem.Application.Dtos.Requests.Product
{
    public class ProductCreateRequestDto : ApiBaseRequest
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
