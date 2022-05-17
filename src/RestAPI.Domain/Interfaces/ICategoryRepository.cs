using RestAPI.Domain.Entities;
using System.Linq;

namespace RestAPI.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<Category> Query();

        void Add(Category category);
    }
}
