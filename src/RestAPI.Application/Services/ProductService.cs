using AutoMapper;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProducts());
        }

        public async Task<ProductDTO> GetProductById(Guid productId)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetProductById(productId));
        }
    }
}
