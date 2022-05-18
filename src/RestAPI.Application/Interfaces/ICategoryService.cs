using RestAPI.Application.DTOs;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;
using System;
using System.Threading.Tasks;

namespace RestAPI.Application.Interfaces
{
    public interface ICategoryService
    {
        PagedResponse<CategoryDTO> GetPagedCategories(CategoryParameters parameters);

        Task AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(Guid id, CategoryDTO categoryDTO);
        Task DeleteCategory(Guid id);
    }
}
