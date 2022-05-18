using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestAPI.Infra.Data.Context;

namespace RestAPI.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<RestApiDbContext>(options => options.UseSqlite("Data Source=RestAPI.db"));
        }
    }
}
