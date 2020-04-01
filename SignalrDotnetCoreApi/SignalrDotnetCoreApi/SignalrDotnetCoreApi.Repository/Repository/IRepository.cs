using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SignalrDotnetCoreApi.Repository.Repository
{
    public interface IRepository<T> where T : class
    {
        ValueTask AddAsync(T entity);

        void Remove(T entity);
        
        void Update(T entity);

        T First();

        Task<T> FirstAsync();

        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}