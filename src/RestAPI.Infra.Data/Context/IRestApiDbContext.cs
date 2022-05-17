using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;

namespace RestAPI.Infra.Data.Context
{
    public interface IRestApiDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }

        bool IsAvailable();
    }
}
