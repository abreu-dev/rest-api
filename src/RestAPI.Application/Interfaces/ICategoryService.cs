using RestAPI.Application.DTOs;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;

namespace RestAPI.Application.Interfaces
{
    public interface ICategoryService
    {
        PagedResponse<CategoryDTO> GetPagedCategories(CategoryParameters parameters);

        Response AddCategory(CategoryDTO categoryDTO);
    }
}
