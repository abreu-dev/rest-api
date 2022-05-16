using RestAPI.Domain.Entities;
using System.Linq;

namespace RestAPI.Domain.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Query();
    }
}
