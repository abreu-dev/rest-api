using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;
using RestAPI.Infra.Data.Context;
using System;
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

        public Category GetCategoryById(Guid id)
        {
            return _restApiDbContext.Categories.Find(id);
        }

        public void AddCategory(Category category)
        {
            _restApiDbContext.Categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _restApiDbContext.Categories.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            _restApiDbContext.Categories.Remove(category);
        }
    }
}
