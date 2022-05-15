using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;
using RestAPI.Infra.Data.Mappings;

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

        public bool IsAvailable()
        {
            return Database.CanConnect();
        }
    }
}
