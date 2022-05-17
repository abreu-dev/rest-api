using RestAPI.Domain.Entities;
using System.Linq;

namespace RestAPI.Domain.Interfaces
{
    public interface IProductRepository
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<Product> Query();
    }
}
