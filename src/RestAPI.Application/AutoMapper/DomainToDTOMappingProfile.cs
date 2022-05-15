using AutoMapper;
using RestAPI.Application.DTOs;
using RestAPI.Domain.Entities;

namespace RestAPI.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Currency, CurrencyDTO>();
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
