using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
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
        private readonly ILog _logger = LogManager.GetLogger(typeof(GrapesController));

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

            _logger.Info("new Grape is added.");

            return Ok();
        }

        [HttpGet]
        [Route("Grapes")]
        public async Task<ActionResult<List<Grape>>> Grapes()
        {
            var result = await _grapeService.GetGrapesAsync();

            _logger.Info("Grapes are fetched.");

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _grapeService.DeleteGrapeAsync(id);

            await _hubService.SendGrapeMessageAsync();

            _logger.Info($"Grape with id:{id} is deleted.");

            return Ok();
        }
    }
}
