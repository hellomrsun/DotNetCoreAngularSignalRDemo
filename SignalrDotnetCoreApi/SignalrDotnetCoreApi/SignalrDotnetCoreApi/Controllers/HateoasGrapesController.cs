using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using SignalrDotnetCoreApi.Database.Entities;
using SignalrDotnetCoreApi.Hateoas;
using SignalrDotnetCoreApi.Service.Services;
using SignalrDotnetCoreApi.Service.SignalRHub;

namespace SignalrDotnetCoreApi.Controllers
{
    [Route("api/v1/hateoas-grapes")]
    [ApiController]
    public class HateoasGrapesController : ControllerBase
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(GrapesController));

        private readonly IGrapeService _grapeService;
        private readonly IHubService _hubService;

        public HateoasGrapesController(
            IGrapeService grapeService,
            IHubService hubService)
        {
            _grapeService = grapeService;
            _hubService = hubService;
        }

        [HttpPost]
        public async ValueTask<ActionResult> Add([FromBody] Grape grape)
        {
            await _grapeService.AddGrapeAsync(grape);

            await _hubService.SendGrapeMessageAsync();

            _logger.Info("new Grape is added.");

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<HateoasModel<IEnumerable<Grape>>>> Grapes()
        {
            var result = await _grapeService.GetGrapesAsync();

            _logger.Info("Grapes are fetched.");

            return Ok(ToHateoasModel(result));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _grapeService.DeleteGrapeAsync(id);

            await _hubService.SendGrapeMessageAsync();

            _logger.Info($"Grape with id:{id} is deleted.");

            return Ok();
        }

        private HateoasModel<T> ToHateoasModel<T>(T grape) where T : class
        {
            var baseUrl = Request.Host + "/api/v1/hateoas-grapes/";

            var links = new List<Link>
            {
                new Link(baseUrl, "add_grape", "POST"),
                new Link(baseUrl, "get_all", "GET"),
                new Link(baseUrl, "delete_grape", "DELETE")
            };

            return new HateoasModel<T>()
            {
                Data = grape,
                Links = links
            };
        }
    }
}
