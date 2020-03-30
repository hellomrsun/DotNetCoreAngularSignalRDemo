using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalrDotnetCoreApi.Database.Entities;
using System;
using System.IO;

namespace SignalrDotnetCoreApi.Database.Context
{
    public class WineDbContext : DbContext, IDbContext
    {
        private static string CodeFirstUpdateConnectionString
        {
            get
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"))
                    .Build();
                var result = config.GetSection("ConnectionStrings")["WineDbConnection"];

                return result;
            }
        }

        public WineDbContext() : this(CodeFirstUpdateConnectionString)
        {
        }

        public WineDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Grape> Grapes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                System.Diagnostics.Debugger.Launch();
            }
#endif

            optionsBuilder.UseSqlServer(CodeFirstUpdateConnectionString);
        }
    }
}
