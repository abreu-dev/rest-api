using RestAPI.Application.DTOs;
using RestAPI.Application.Parameters;
using System.Collections.Generic;

namespace RestAPI.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
        PagedList<ProductDTO> GetProducts(ProductParameters productParameters);
    }
}
