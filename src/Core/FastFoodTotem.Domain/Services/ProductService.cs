using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses.Product;
using FastFoodTotem.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Domain.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductCreateResponseDto> CreateAsync(ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDeleteResponseDto> DeleteAsync(ProductDeleteRequestDto productCreateRequestDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductEditResponseDto> EditAsync(ProductEditRequestDto productCreateRequestDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductGetByCategoryResponseDto> GetByCategoryAsync(ProductGetByCategoryRequestDto productGetByCategoryRequestDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
