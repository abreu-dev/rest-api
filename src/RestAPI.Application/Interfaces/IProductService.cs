using RestAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(Guid productId);
    }
}
