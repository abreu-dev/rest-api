using RestAPI.Application.DTOs;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;

namespace RestAPI.Application.Interfaces
{
    public interface IProductService
    {
        PagedResponse<ProductDTO> GetPagedProducts(ProductParameters parameters);
    }
}
