using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalrDotnetCoreApi.Database.Entities;
using SignalrDotnetCoreApi.Repository.UnitOfWork;

namespace SignalrDotnetCoreApi.Service.Services
{
    public class GrapeService : IGrapeService
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public GrapeService(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<IEnumerable<Grape>> GetGrapesAsync()
        {
            using var uow = _uowFactory.Create();
            var repo = uow.GetRepository<Grape>();
            var result = await repo.GetAllAsync();

            return result;
        }

        public async Task<int> AddGrapeAsync(Grape grape)
        {
            using var uow = _uowFactory.Create();
            var repo = uow.GetRepository<Grape>();
            await repo.AddAsync(grape);
            return await uow.SaveChangesAsync();
        }

        public async Task<int> DeleteGrapeAsync(int id)
        {
            using var uow = _uowFactory.Create();
            var repo = uow.GetRepository<Grape>();
            var item = await repo.Where(x => x.Id == id).FirstAsync();
            repo.Remove(item);
            return await uow.SaveChangesAsync();
        }
    }
}
