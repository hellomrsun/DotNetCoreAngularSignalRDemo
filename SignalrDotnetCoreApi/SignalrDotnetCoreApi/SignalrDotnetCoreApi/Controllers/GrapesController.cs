using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalrDotnetCoreApi.Database.Entities;
using SignalrDotnetCoreApi.Service.Services;
using SignalrDotnetCoreApi.Service.SignalRHub;

namespace SignalrDotnetCoreApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GrapesController : ControllerBase
    {
        private readonly IGrapeService _grapeService;
        private readonly IHubService _hubService;

        public GrapesController(
            IGrapeService grapeService,
            IHubService hubService)
        {
            _grapeService = grapeService;
            _hubService = hubService;
        }

        [HttpPut]
        [Route("Add")]
        public async ValueTask<ActionResult> Add([FromBody] Grape grape)
        {
            await _grapeService.AddGrapeAsync(grape);
            
            await _hubService.SendGrapeMessageAsync();

            return Ok();
        }

        [HttpGet]
        [Route("Grapes")]
        public async Task<ActionResult<List<Grape>>> Grapes()
        {
            var result = await _grapeService.GetGrapesAsync();

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _grapeService.DeleteGrapeAsync(id);

            await _hubService.SendGrapeMessageAsync();

            return Ok();
        }
    }
}
