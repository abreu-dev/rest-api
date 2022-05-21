using Microsoft.AspNetCore.JsonPatch;
using RestAPI.Application.DTOs;
using RestAPI.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Application.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetCategories(CategoryParameters parameters);

        CategoryDTO GetCategoryById(Guid id);

        Task AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(Guid id, CategoryDTO categoryDTO);
        Task PatchCategory(Guid id, JsonPatchDocument<CategoryDTO> patchCategoryDTO);
        Task DeleteCategory(Guid id);
    }
}
