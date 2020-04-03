using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalrDotnetCoreApi.Service.Models;
using SignalrDotnetCoreApi.Service.Services;

namespace SignalrDotnetCoreApi.Service.SignalRHub
{
    public class HubService : IHubService
    {
        private readonly IHubContext<GrapeHub> _hubContext;
        private readonly IGrapeService _grapeService;

        public HubService(
            IHubContext<GrapeHub> hubContext,
            IGrapeService grapeService)
        {
            _hubContext = hubContext;
            _grapeService = grapeService;
        }

        public async Task SendGrapeMessageAsync()
        {
            var grapes = await _grapeService.GetGrapesAsync();
            var notificationInfo = new NotificationInfo
            {
                MessageType = MessageType.GrapesUpdate,
                Message = grapes,
                DateTime = DateTime.Now
            };

            await Send("GrapesUpdate", notificationInfo);
        }

        public async Task Send<T>(string methodName, T message) where T : class
        {
            await _hubContext.Clients.All.SendAsync(methodName, message);
        }
    }
}
