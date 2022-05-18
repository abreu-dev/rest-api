using Microsoft.AspNetCore.JsonPatch;
using RestAPI.Application.DTOs;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;
using System;
using System.Threading.Tasks;

namespace RestAPI.Application.Interfaces
{
    public interface IProductService
    {
        PagedResponse<ProductDTO> GetPagedProducts(ProductParameters parameters);

        ProductDTO GetProductById(Guid id);

        Task AddProduct(ProductDTO productDTO);
        Task UpdateProduct(Guid id, ProductDTO productDTO);
        Task PatchProduct(Guid id, JsonPatchDocument<ProductDTO> patchProductDTO);
        Task DeleteProduct(Guid id);
    }
}
