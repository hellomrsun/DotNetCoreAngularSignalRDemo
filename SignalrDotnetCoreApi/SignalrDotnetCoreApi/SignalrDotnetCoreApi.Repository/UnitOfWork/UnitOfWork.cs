using SignalrDotnetCoreApi.Database.Context;
using SignalrDotnetCoreApi.Repository.Repository;

namespace SignalrDotnetCoreApi.Repository.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
