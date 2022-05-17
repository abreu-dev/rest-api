using Microsoft.AspNetCore.Mvc;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;

namespace RestAPI.API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("api/categories:paginated")]
        public PagedResponse<CategoryDTO> GetPagedCategories([FromQuery] CategoryParameters parameters)
        {
            return _categoryService.GetPagedCategories(parameters);
        }
    }
}
