using AutoMapper;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;
using RestAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public PagedResponse<ProductDTO> GetPagedProducts(ProductParameters parameters)
        {
            var source = _productRepository
                .Query()
                .OrderBy(p => p.Name);

            var totalItems = source.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)parameters.Size);
            var items = _mapper.Map<IEnumerable<ProductDTO>>(source
                .Skip(parameters.Page * parameters.Size)
                .Take(parameters.Size)
                .ToList());

            return new PagedResponse<ProductDTO>(items, parameters.Page, totalItems, totalPages);
        }
    }
}
