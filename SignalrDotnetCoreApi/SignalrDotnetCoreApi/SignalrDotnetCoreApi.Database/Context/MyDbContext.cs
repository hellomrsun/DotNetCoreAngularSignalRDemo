using Microsoft.EntityFrameworkCore;
using SignalrDotnetCoreApi.Common.Entities;

namespace SignalrDotnetCoreApi.Database.Context
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;

        int SaveChanges();
    }

    public class MyDbContext : DbContext, IDbContext
    {
        public MyDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Grape> Grapes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=StoreDB;");
        //}
    }
}
