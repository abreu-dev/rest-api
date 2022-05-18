using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestAPI.Application.AutoMapper;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Services;
using RestAPI.Domain.CommandHandlers;
using RestAPI.Domain.Commands.CategoryCommands;
using RestAPI.Domain.Commands.ProductCommands;
using RestAPI.Domain.Interfaces;
using RestAPI.Domain.MediatorHandler;
using RestAPI.Domain.Notifications;
using RestAPI.Infra.Data.Context;
using RestAPI.Infra.Data.Repositories;

namespace RestAPI.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application - AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile), typeof(DTOToDomainMappingProfile));

            // Application - Services
            services.AddScoped<IHealthService, HealthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            // Domain - Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddCategoryCommand, Unit>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoryCommand, Unit>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCategoryCommand, Unit>, CategoryCommandHandler>();

            services.AddScoped<IRequestHandler<AddProductCommand, Unit>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, Unit>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, Unit>, ProductCommandHandler>();

            // Infra - Data - Contexts
            services.AddScoped<IRestApiDbContext, RestApiDbContext>();
            services.AddScoped<RestApiDbContext>();

            // Infra - Data - Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
