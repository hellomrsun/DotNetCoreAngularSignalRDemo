using SignalrDotnetCoreApi.Repository.Repository;
using System;
using System.Threading.Tasks;

namespace SignalrDotnetCoreApi.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        Task<int> SaveChangesAsync();
    }
}
