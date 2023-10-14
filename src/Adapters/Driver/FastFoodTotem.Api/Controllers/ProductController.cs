using FastFoodTotem.Api.Controllers.Base;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodTotem.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{ver:apiVersion}/product")]
    [Produces("application/json")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="productCreateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        
        ///     }
        ///
        /// </remarks>
        /// <returns>Id of the new product created</returns>
        /// <response code="200">Request was processed sucessfully</response>
        /// <response code="400">Body in the request was wrong.</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken)
        => await Task.FromResult(Ok());

        // <summary>
        /// Edit a product.
        /// </summary>
        /// <param name="productEditRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT
        ///     {
        ///        
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Request was processed sucessfully</response>
        /// <response code="400">Body in the request was wrong.</response>
        /// <response code="500">Internal server error</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit([FromBody] ProductEditRequestDto productEditRequestDto, CancellationToken cancellationToken)
        => await Task.FromResult(Ok());

        // <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="productEditRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE
        ///     {
        ///        
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Request was processed sucessfully</response>
        /// <response code="400">Body in the request was wrong.</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromBody] ProductDeleteRequestDto productDeleteRequestDto, CancellationToken cancellationToken)
        => await Task.FromResult(Ok());

        // <summary>
        /// Retrieve a list of products by category.
        /// </summary>
        /// <param name="productEditRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /category
        ///     {
        ///        
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Request was processed sucessfully</response>
        /// <response code="400">Body in the request was wrong.</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCategory([FromRoute] Guid categoryId, CancellationToken cancellationToken)
        => await Task.FromResult(Ok(categoryId));
    }
}
