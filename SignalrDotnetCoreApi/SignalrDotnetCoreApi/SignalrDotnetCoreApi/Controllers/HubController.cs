using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalrDotnetCoreApi.Models;
using System.Threading.Tasks;

namespace SignalrDotnetCoreApi.Controllers
{
    [Route("api/v1/hub")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public HubController(IHubContext<ChatHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> Send(Message message)
        {
            await _hubContext.Clients.All.SendAsync("Notify", message);

            return StatusCode(200, true);
        }
    }
}
