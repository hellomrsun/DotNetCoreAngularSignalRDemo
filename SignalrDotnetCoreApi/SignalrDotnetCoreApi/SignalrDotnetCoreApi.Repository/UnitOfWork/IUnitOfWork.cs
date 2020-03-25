using SignalrDotnetCoreApi.Repository.Repository;

namespace SignalrDotnetCoreApi.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();
    }
}
