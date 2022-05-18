using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;
using RestAPI.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace RestAPI.API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly ICategoryService _categoryService;

        public CategoriesController(INotificationHandler<DomainNotification> notifications, ICategoryService categoryService)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("api/categories:paginated")]
        public PagedResponse<CategoryDTO> GetPagedCategories([FromQuery] CategoryParameters parameters)
        {
            return _categoryService.GetPagedCategories(parameters);
        }

        [HttpPost]
        [Route("api/categories")]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.AddCategory(categoryDTO);

            if (_notifications.HasNotifications())
            {
                var response = new Response("/categories");

                _notifications.GetNotifications().ForEach(notification =>
                {
                    response.Errors.Add(new ResponseError(notification.Type, notification.Error, notification.Detail));
                });

                return BadRequest(response);
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/categories/{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.UpdateCategory(id, categoryDTO);

            if (_notifications.HasNotifications())
            {
                var response = new Response("/categories");

                _notifications.GetNotifications().ForEach(notification =>
                {
                    response.Errors.Add(new ResponseError(notification.Type, notification.Error, notification.Detail));
                });

                return BadRequest(response);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/categories/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.DeleteCategory(id);

            if (_notifications.HasNotifications())
            {
                var response = new Response("/categories");

                _notifications.GetNotifications().ForEach(notification =>
                {
                    response.Errors.Add(new ResponseError(notification.Type, notification.Error, notification.Detail));
                });

                return BadRequest(response);
            }

            return Ok();
        }
    }
}
