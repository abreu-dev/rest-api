using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;
using RestAPI.Infra.Data.Context;
using System.Linq;

namespace RestAPI.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRestApiDbContext _restApiDbContext;

        public IUnitOfWork UnitOfWork => _restApiDbContext;

        public CategoryRepository(IRestApiDbContext restApiDbContext)
        {
            _restApiDbContext = restApiDbContext;
        }

        public IQueryable<Category> Query()
        {
            return _restApiDbContext.Categories;
        }

        public void Add(Category category)
        {
            _restApiDbContext.Categories.Add(category);
        }
    }
}
