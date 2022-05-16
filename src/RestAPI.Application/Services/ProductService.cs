using AutoMapper;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;
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

        public IEnumerable<ProductDTO> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(_productRepository.Query().ToList());
        }

        public PagedList<ProductDTO> GetProducts(ProductParameters productParameters)
        {
            var pagedList = PagedList<Product>.ToPagedList(
                _productRepository.Query().OrderBy(on => on.Name),
                productParameters.Page,
                productParameters.Size);

            var mappedPagedList = new PagedList<ProductDTO>(
                _mapper.Map<IEnumerable<ProductDTO>>(pagedList.Data),
                pagedList.TotalItems,
                pagedList.CurrentPage,
                pagedList.TotalPages);

            return mappedPagedList;
        }
    }
}
