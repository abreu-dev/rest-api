using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;
using RestAPI.Infra.Data.Context;
using System.Linq;

namespace RestAPI.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRestApiDbContext _restApiDbContext;

        public ProductRepository(IRestApiDbContext restApiDbContext)
        {
            _restApiDbContext = restApiDbContext;
        }

        public IQueryable<Product> Query()
        {
            return _restApiDbContext.Products
                .Include(p => p.Category);
        }
    }
}
