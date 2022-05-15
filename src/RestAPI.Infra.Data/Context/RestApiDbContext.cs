using Microsoft.EntityFrameworkCore;

namespace RestAPI.Infra.Data.Context
{
    public class RestApiDbContext : DbContext, IRestApiDbContext
    {
        public RestApiDbContext(DbContextOptions<RestApiDbContext> options) : base(options) { }

        public bool IsAvailable()
        {
            return Database.CanConnect();
        }
    }
}
