using System.Threading.Tasks;

namespace RestAPI.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
