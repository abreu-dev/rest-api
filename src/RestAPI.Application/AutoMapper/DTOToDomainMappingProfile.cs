using AutoMapper;
using RestAPI.Application.DTOs;
using RestAPI.Domain.Entities;
using System;

namespace RestAPI.Application.AutoMapper
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<CategoryDTO, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => GetIdFromDTO(src.Category)))
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }

        public static Guid? GetIdFromDTO(DTO dto)
        {
            return dto?.Id;
        }
    }
}
