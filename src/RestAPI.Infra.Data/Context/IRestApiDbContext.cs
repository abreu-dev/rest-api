using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;

namespace RestAPI.Infra.Data.Context
{
    public interface IRestApiDbContext : IUnitOfWork
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }

        bool IsAvailable();
    }
}
