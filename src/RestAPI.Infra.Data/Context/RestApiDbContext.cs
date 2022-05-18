using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;
using RestAPI.Infra.Data.Mappings;
using System;

namespace RestAPI.Infra.Data.Context
{
    public class RestApiDbContext : DbContext, IRestApiDbContext
    {
        public RestApiDbContext(DbContextOptions<RestApiDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            base.OnModelCreating(modelBuilder);
        }

        public bool Commit()
        {
            return SaveChanges() > 0;
        }

        public bool IsAvailable()
        {
            return Database.CanConnect();
        }

        private void LogChangeTracker()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: { entry.State}");
            }
        }
    }
}
