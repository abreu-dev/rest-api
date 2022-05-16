using Microsoft.AspNetCore.Mvc;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;

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
        public PagedList<ProductDTO> GetProducts([FromQuery] ProductParameters productParameters)
        {
            return _productService.GetProducts(productParameters);
        }
    }
}
