using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;
using RestAPI.Infra.Data.Context;
using System;
using System.Linq;

namespace RestAPI.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRestApiDbContext _restApiDbContext;

        public IUnitOfWork UnitOfWork => _restApiDbContext;

        public ProductRepository(IRestApiDbContext restApiDbContext)
        {
            _restApiDbContext = restApiDbContext;
        }

        public IQueryable<Product> Query()
        {
            return _restApiDbContext.Products
                .Include(p => p.Category);
        }

        public Product GetProductById(Guid id)
        {
            var product = _restApiDbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null) return null;

            _restApiDbContext.Entry(product).Reference(x => x.Category).Load();

            return product;
        }

        public void AddProduct(Product product)
        {
            _restApiDbContext.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _restApiDbContext.Products.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            _restApiDbContext.Products.Remove(product);
        }
    }
}
