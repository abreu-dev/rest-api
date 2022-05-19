using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using RestAPI.Application.DTOs;
using RestAPI.Application.Helpers;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;
using RestAPI.Domain.Commands.ProductCommands;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;
using RestAPI.Domain.MediatorHandler;
using RestAPI.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace RestAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler _mediator;

        public ProductService(IMapper mapper, IProductRepository productRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _mediator = mediator;
        }

        public PagedResponse<ProductDTO> GetPagedProducts(ProductParameters parameters)
        {
            var source = _productRepository
                .Query();

            source = string.IsNullOrEmpty(parameters.Order) ? source.OrderBy(p => p.Name) : source.OrderBy(parameters.Order);

            if (!string.IsNullOrEmpty(parameters.Name))
            {
                source = source.ApplyFilter("Name", parameters.Name);
            }

            if (!string.IsNullOrEmpty(parameters.Description))
            {
                source = source.ApplyFilter("Description", parameters.Description);
            }

            var totalItems = source.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)parameters.Size);
            var items = _mapper.Map<IEnumerable<ProductDTO>>(source
                .Skip(parameters.Page * parameters.Size)
                .Take(parameters.Size)
                .ToList());

            return new PagedResponse<ProductDTO>(items, parameters.Page, totalItems, totalPages);
        }

        public ProductDTO GetProductById(Guid id)
        {
            return _mapper.Map<ProductDTO>(_productRepository.GetProductById(id));
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            var command = new AddProductCommand()
            {
                Product = _mapper.Map<Product>(productDTO)
            };

            await _mediator.SendCommand(command);
        }

        public async Task UpdateProduct(Guid id, ProductDTO productDTO)
        {
            var command = new UpdateProductCommand(id)
            {
                Product = _mapper.Map<Product>(productDTO)
            };

            await _mediator.SendCommand(command);
        }

        public async Task PatchProduct(Guid id, JsonPatchDocument<ProductDTO> patchProductDTO)
        {
            var productDTO = GetProductById(id);

            if (productDTO == null)
            {
                await _mediator.RaiseDomainNotificationAsync(
                    new DomainNotification("NotFound", "Product not found", "The informed 'Product' was not found"));
                return;
            }

            patchProductDTO.ApplyTo(productDTO);

            var command = new UpdateProductCommand(id)
            {
                Product = _mapper.Map<Product>(productDTO)
            };

            await _mediator.SendCommand(command);
        }

        public async Task DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommand(id);

            await _mediator.SendCommand(command);
        }
    }
}
