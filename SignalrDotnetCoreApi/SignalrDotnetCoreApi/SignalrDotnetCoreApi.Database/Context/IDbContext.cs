using Microsoft.EntityFrameworkCore;
using SignalrDotnetCoreApi.Database.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalrDotnetCoreApi.Database.Context
{
    public interface IDbContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        DbSet<Grape> Grapes { get; set; }
    }
}
