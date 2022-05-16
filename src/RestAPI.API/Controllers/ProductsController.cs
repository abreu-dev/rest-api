using Microsoft.AspNetCore.Mvc;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using System.Collections.Generic;

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
        [Route("api/products")]
        public IEnumerable<ProductDTO> GetProducts([FromQuery] ProductParameters productParameters)
        {
            return _productService.GetProducts(productParameters);
        }

        [HttpGet]
        [Route("api/products:paginated")]
        public PagedList<ProductDTO> GetPaginatedProducts([FromQuery] ProductParameters productParameters)
        {
            return _productService.GetPaginatedProducts(productParameters);
        }
    }
}
