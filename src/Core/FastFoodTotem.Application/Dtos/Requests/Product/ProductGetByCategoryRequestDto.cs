namespace FastFoodTotem.Application.Dtos.Requests.Product;

public class ProductGetByCategoryRequestDto : ApiBaseRequest
{
    public IEnumerable<ProductRequestData> Products { get; set; }
}

public class ProductRequestData
{

}