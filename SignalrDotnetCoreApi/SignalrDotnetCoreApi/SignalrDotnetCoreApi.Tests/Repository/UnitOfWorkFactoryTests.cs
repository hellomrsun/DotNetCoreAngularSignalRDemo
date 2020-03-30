//using Microsoft.Extensions.Configuration;
//using Moq;
//using NFluent;
//using SignalrDotnetCoreApi.Common.Configuration;
//using SignalrDotnetCoreApi.Database.Entities;
//using SignalrDotnetCoreApi.Repository.UnitOfWork;
//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Xunit;

//namespace SignalrDotnetCoreApi.Tests.Repository
//{
//    public class UnitOfWorkFactoryTests
//    {
//        private IUnitOfWorkFactory _target;
//        private IConfigurationRetriever _configRetriever;
//        private IConfigurationParser _configParser;
//        private IConfiguration _config;

//        public UnitOfWorkFactoryTests()
//        {
//            _config = new ConfigurationBuilder()
//                .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.test.json"))
//                .Build();

//            _configParser = new ConfigurationParser(_config);
//            _configRetriever = new ConfigurationRetriever(_configParser);
//            _target = new UnitOfWorkFactory(_configRetriever);
//        }

//        [Fact]
//        public void Should_create_dbcontext()
//        {
//            //Arrange

//            //Act
//            using(var uow = _target.Create())
//            {
//                //Assert
//                Check.That(uow).IsNotNull();
//                var repo = uow.GetRepository<Test>();
//                var first = repo.First();
//                Check.That(first).IsNotNull();
//            }
//        }

//        [Fact]
//        public async Task Should_create_dbcontext_insert()
//        {
//            //Arrange

//            //Act
//            using (var uow = _target.Create())
//            {
//                var repo = uow.GetRepository<Test>();
//                var test = new Test()
//                {
//                    Id = 1
//                };
//                await repo.AddAsync(test);
//                await uow.SaveChangesAsync();
//            }

//        }
//    }
//}
