using Microsoft.EntityFrameworkCore;
using SignalrDotnetCoreApi.Database.Entities;

namespace SignalrDotnetCoreApi.Database.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Benefit> Benefits { get; set; }

        public DbSet<MembershipVsBenefit> MembershipVsBenefits { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=StoreDB;");
        //}
    }
}
