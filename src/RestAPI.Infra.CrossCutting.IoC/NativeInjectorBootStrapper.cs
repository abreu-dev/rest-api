using Microsoft.Extensions.DependencyInjection;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Services;
using RestAPI.Infra.Data.Context;

namespace RestAPI.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            services.AddScoped<IHealthService, HealthService>();

            services.AddScoped<IRestApiDbContext, RestApiDbContext>();
            services.AddScoped<RestApiDbContext>();
        }
    }
}
