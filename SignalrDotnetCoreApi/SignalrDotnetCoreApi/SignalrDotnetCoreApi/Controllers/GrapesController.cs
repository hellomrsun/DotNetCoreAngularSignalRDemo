using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalrDotnetCoreApi.Database.Entities;
using SignalrDotnetCoreApi.Service.Services;
using SignalrDotnetCoreApi.Service.SignalRHub;

namespace SignalrDotnetCoreApi.Controllers
{
    [Route("api/v1/grapes")]
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

        /// <summary>
        /// Create a new grape
        /// </summary>
        /// <param name="grape">Grape</param>
        /// <returns>grape creation result</returns>
        /// <response code="201">Grape is created</response>
        /// <response code="500">Internal Server Error</response> 
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async ValueTask<ActionResult> Add([FromBody] Grape grape)
        {
            try
            {
                await _grapeService.AddGrapeAsync(grape);

                await _hubService.SendGrapeMessageAsync();

                _logger.Info("new Grape is added.");

                return StatusCode(201, "Grape created");
            }
            catch (Exception e)
            {
                _logger.Error("Failed to create grape.", e);
                return StatusCode(500, "Server error");
            }
        }

        /// <summary>
        /// Get all the grapes
        /// </summary>
        /// <returns>A list of grapes</returns>
        /// <response code="200">Returns a list of grapes</response>
        /// <response code="500">Internal Server Error</response> 
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Grape>>> Grapes()
        {
            try
            {
                var result = await _grapeService.GetGrapesAsync();

                _logger.Info("Grapes are fetched.");

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.Error("Failed to retrieve grapes.", e);
                return StatusCode(500, "Failed");
            }
        }

        /// <summary>
        /// Delete a grape
        /// </summary>
        /// <param name="id">grape id</param>
        /// <returns></returns>
        /// <response code="200">Deletion is ok</response>
        /// <response code="500">Internal Server Error</response> 
        [HttpDelete]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _grapeService.DeleteGrapeAsync(id);

                await _hubService.SendGrapeMessageAsync();

                _logger.Info($"Grape with id:{id} is deleted.");

                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error("Failed to delete grape.", e);
                return StatusCode(500, "Failed");
            }
        }
    }
}
