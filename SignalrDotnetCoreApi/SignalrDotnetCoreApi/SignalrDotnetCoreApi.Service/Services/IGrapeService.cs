using System.Collections.Generic;
using System.Threading.Tasks;
using SignalrDotnetCoreApi.Database.Entities;

namespace SignalrDotnetCoreApi.Service.Services
{
    public interface IGrapeService
    {
        Task<IEnumerable<Grape>> GetGrapesAsync();

        Task<int> DeleteGrapeAsync(int id);

        Task<int> AddGrapeAsync(Grape grape);
    }
}