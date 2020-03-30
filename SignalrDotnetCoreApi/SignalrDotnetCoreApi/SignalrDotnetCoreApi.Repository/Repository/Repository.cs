using Microsoft.EntityFrameworkCore;
using SignalrDotnetCoreApi.Database.Context;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrDotnetCoreApi.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly IDbContext dbContext;

        public Repository(IDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            this.dbContext = dbContext;
        }

        public async ValueTask AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public Task<T> FirstAsync()
        {
            return _dbSet.FirstAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public T First()
        {
            return _dbSet.First();
        }
    }
}