using AutoMapper;
using RestAPI.Application.DTOs;
using RestAPI.Application.Helpers;
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

        public IEnumerable<ProductDTO> GetProducts(ProductParameters productParameters)
        {
            var products = _productRepository
                .Query();
            products = ApplyFilters(products, productParameters);
            products = products.OrderBy(on => on.Name);

            return _mapper.Map<IEnumerable<ProductDTO>>(products.ToList());
        }

        public PagedList<ProductDTO> GetPaginatedProducts(ProductParameters productParameters)
        {
            var products = _productRepository
                .Query();
            products = ApplyFilters(products, productParameters);
            products = products.OrderBy(on => on.Name);

            var pagedList = PagedList<Product>.ToPagedList(
                products,
                productParameters.Page,
                productParameters.Size);

            var mappedPagedList = new PagedList<ProductDTO>(
                _mapper.Map<IEnumerable<ProductDTO>>(pagedList.Data),
                pagedList.TotalItems,
                pagedList.CurrentPage,
                pagedList.TotalPages);

            return mappedPagedList;
        }

        public IQueryable<Product> ApplyFilters(IQueryable<Product> products, ProductParameters productParameters)
        {
            if (!string.IsNullOrEmpty(productParameters.Name))
            {
                products = LinqLambdaBuilder.ApplyFilter(products, "Name", productParameters.Name);
            }

            if (!string.IsNullOrEmpty(productParameters.Description))
            {
                products = LinqLambdaBuilder.ApplyFilter(products, "Description", productParameters.Description);
            }

            return products;
        }
    }
}
