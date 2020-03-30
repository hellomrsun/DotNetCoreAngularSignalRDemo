using SignalrDotnetCoreApi.Common.Configuration;
using SignalrDotnetCoreApi.Database.Context;

namespace SignalrDotnetCoreApi.Repository.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IConfigurationRetriever _configRetriever;

        public UnitOfWorkFactory(IConfigurationRetriever configurationRetriever)
        {
            this._configRetriever = configurationRetriever;
        }

        public IUnitOfWork Create()
        {
            //var dbContext = new WineDbContext(_configRetriever.WineDbConnectionString);
            var dbContext = new WineDbContext();
            return new UnitOfWork(dbContext);
        }
    }
}
