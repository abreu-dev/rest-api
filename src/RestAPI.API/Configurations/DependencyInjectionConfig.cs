using Microsoft.Extensions.DependencyInjection;
using RestAPI.Infra.CrossCutting.IoC;

namespace RestAPI.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
