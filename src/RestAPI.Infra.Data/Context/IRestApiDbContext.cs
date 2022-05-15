using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;

namespace RestAPI.Infra.Data.Context
{
    public interface IRestApiDbContext : IUnitOfWork
    {
        DbSet<Product> Product { get; set; }
        DbSet<ProductCategory> ProductCategory { get; set; }

        bool IsAvailable();
    }
}
