using Microsoft.EntityFrameworkCore;
using SignalrDotnetCoreApi.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SignalrDotnetCoreApi.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly DbSet<T> _dbSet;

        public Repository(IDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}