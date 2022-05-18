using AutoMapper;
using RestAPI.Application.DTOs;
using RestAPI.Domain.Entities;

namespace RestAPI.Application.AutoMapper
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<CurrencyDTO, Currency>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}
