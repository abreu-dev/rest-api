using Microsoft.AspNetCore.Mvc;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("{productId:guid}")]
        public async Task<ProductDTO> GetProductById(Guid productId)
        {
            return await _productService.GetProductById(productId);
        }
    }
}
