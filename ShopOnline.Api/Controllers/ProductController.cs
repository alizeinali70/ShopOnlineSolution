using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItems();
                var productcategories = await this.productRepository.GetCategories();

                if (products == null || productcategories == null)
                    return NotFound();
                else
                {
                    var productsDtos = products.ConvertToDto(productcategories);
                    return Ok(productsDtos);
                }

            }
            catch (Exception exp)
            {
return StatusCode(StatusCodes.Status500InternalServerError," Error Retrieving Data : "+ exp);
            }
        }
    }
}
