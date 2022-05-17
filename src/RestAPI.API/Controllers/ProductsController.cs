using Microsoft.AspNetCore.Mvc;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;

namespace RestAPI.API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("api/products:paginated")]
        public PagedResponse<ProductDTO> GetPagedProducts([FromQuery] ProductParameters productParameters)
        {
            return _productService.GetPagedProducts(productParameters);
        }
    }
}
