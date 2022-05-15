using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;
using RestAPI.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRestApiDbContext _restApiDbContext;

        public ProductRepository(IRestApiDbContext restApiDbContext)
        {
            _restApiDbContext = restApiDbContext;
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            var products = await GetProducts();
            return products.FirstOrDefault(x => x.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _restApiDbContext.Product
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
