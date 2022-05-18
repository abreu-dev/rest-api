using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;

namespace RestAPI.Infra.Data.Context
{
    public interface IRestApiDbContext : IUnitOfWork
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        bool IsAvailable();
    }
}
