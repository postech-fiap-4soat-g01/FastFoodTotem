using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.Shared.BaseResponse;
using FastFoodTotem.Application.UseCases.Product.CreateProduct;
using FastFoodTotem.Application.UseCases.Product.DeleteProduct;
using FastFoodTotem.Application.UseCases.Product.EditProduct;
using FastFoodTotem.Application.UseCases.Product.GetProductByCategory;
using FastFoodTotem.Domain.Enums;
using FastFoodTotem.Domain.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/product")]
    [Produces("application/json")]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IValidationNotifications validationNotifications, IMediator mediator)
            : base(validationNotifications)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="createProductRequest"></param>
        /// <param name="cancellationToken"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<CreateProductResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<CreateProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createProductRequest, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(createProductRequest, cancellationToken);
            return await Return(new ApiBaseResponse<CreateProductResponse>() { Data = data });
        }

        /// <summary>
        /// Edit a product.
        /// </summary>
        /// <param name="editProductRequest"></param>
        /// <param name="cancellationToken"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<EditProductResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<EditProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpPut]
        public async Task<IActionResult> EditProduct([FromBody] EditProductRequest editProductRequest, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(editProductRequest, cancellationToken);
            return await Return(new ApiBaseResponse<EditProductResponse>() { Data = data });
        }

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cancellationToken"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<DeleteProductResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<DeleteProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new DeleteProductRequest(productId), cancellationToken);
            return await Return(new ApiBaseResponse<DeleteProductResponse>() { Data = data });
        }

        /// <summary>
        /// Retrieve a list of products by category.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cancellationToken"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiBaseResponse<GetProductByCategoryResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiBaseResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiBaseResponse<GetProductByCategoryResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiBaseResponse))]
        [HttpGet("category/{type}")]
        public async Task<IActionResult> GetProductByCategory([FromRoute] CategoryType type, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new GetProductByCategoryRequest(type), cancellationToken);
            return await Return(new ApiBaseResponse<GetProductByCategoryResponse>() { Data = data });
        }
    }
}
