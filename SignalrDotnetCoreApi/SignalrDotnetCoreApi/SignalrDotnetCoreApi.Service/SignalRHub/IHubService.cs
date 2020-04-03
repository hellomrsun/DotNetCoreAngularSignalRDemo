using System.Threading.Tasks;

namespace SignalrDotnetCoreApi.Service.SignalRHub
{
    public interface IHubService
    {
        Task SendGrapeMessageAsync();
    }
}