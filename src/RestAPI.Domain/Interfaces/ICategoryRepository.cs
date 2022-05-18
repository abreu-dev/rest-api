using RestAPI.Domain.Entities;
using System;
using System.Linq;

namespace RestAPI.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<Category> Query();

        Category GetCategoryById(Guid id);

        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
