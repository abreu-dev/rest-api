using RestAPI.Domain.Entities;
using System.Linq;

namespace RestAPI.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Query();
    }
}
