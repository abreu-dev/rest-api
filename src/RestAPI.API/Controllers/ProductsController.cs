using MediatR;
using Microsoft.AspNetCore.JsonPatch;
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
    public class ProductsController : BaseController
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IProductService _productService;

        public ProductsController(INotificationHandler<DomainNotification> notifications, IProductService productService)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _productService = productService;
        }

        [HttpGet]
        [Route("products:paginated")]
        public PagedResponse<ProductDTO> GetPagedProducts([FromQuery] ProductParameters parameters)
        {
            return _productService.GetPagedProducts(parameters);
        }

        [HttpGet]
        [Route("products/{id:guid}")]
        public ProductDTO Get(Guid id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        [Route("products")]
        public async Task<IActionResult> Post([FromBody] ProductDTO productDTO)
        {
            await _productService.AddProduct(productDTO);

            if (_notifications.HasNotifications())
            {
                var response = new Response("/products");

                _notifications.GetNotifications().ForEach(notification =>
                {
                    response.Errors.Add(new ResponseError(notification.Type, notification.Error, notification.Detail));
                });

                return BadRequest(response);
            }

            return Ok();
        }

        [HttpPut]
        [Route("products/{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductDTO productDTO)
        {
            await _productService.UpdateProduct(id, productDTO);

            if (_notifications.HasNotifications())
            {
                var response = new Response("/products");

                _notifications.GetNotifications().ForEach(notification =>
                {
                    response.Errors.Add(new ResponseError(notification.Type, notification.Error, notification.Detail));
                });

                return BadRequest(response);
            }

            return Ok();
        }

        [HttpPatch]
        [Route("products/{id:guid}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<ProductDTO> patchProductDTO)
        {
            await _productService.PatchProduct(id, patchProductDTO);

            if (_notifications.HasNotifications())
            {
                var response = new Response("/products");

                _notifications.GetNotifications().ForEach(notification =>
                {
                    response.Errors.Add(new ResponseError(notification.Type, notification.Error, notification.Detail));
                });

                return BadRequest(response);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("products/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteProduct(id);

            if (_notifications.HasNotifications())
            {
                var response = new Response("/products");

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
