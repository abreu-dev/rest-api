using Microsoft.Extensions.DependencyInjection;
using RestAPI.Application.AutoMapper;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Services;
using RestAPI.Domain.Interfaces;
using RestAPI.Infra.Data.Context;
using RestAPI.Infra.Data.Repositories;

namespace RestAPI.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            // Application
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IHealthService, HealthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            // Infra - Data
            services.AddScoped<IRestApiDbContext, RestApiDbContext>();
            services.AddScoped<RestApiDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
