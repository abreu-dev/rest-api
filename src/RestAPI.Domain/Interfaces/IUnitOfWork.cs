namespace RestAPI.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
