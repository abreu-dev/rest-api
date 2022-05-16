using RestAPI.Application.DTOs;
using RestAPI.Application.Parameters;

namespace RestAPI.Application.Interfaces
{
    public interface IProductService
    {
        PagedList<ProductDTO> GetProducts(ProductParameters productParameters);
    }
}
