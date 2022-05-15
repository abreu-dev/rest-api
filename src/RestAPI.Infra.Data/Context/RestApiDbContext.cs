using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;
using RestAPI.Infra.Data.Mappings;
using System.Threading.Tasks;

namespace RestAPI.Infra.Data.Context
{
    public class RestApiDbContext : DbContext, IRestApiDbContext
    {
        public RestApiDbContext(DbContextOptions<RestApiDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }

        public bool IsAvailable()
        {
            return Database.CanConnect();
        }
    }
}
