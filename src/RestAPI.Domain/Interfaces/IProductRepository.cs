using RestAPI.Domain.Entities;
using System;
using System.Linq;

namespace RestAPI.Domain.Interfaces
{
    public interface IProductRepository
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<Product> Query();

        Product GetProductById(Guid id);

        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
