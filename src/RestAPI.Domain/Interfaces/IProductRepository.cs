using RestAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(Guid productId);
    }
}
