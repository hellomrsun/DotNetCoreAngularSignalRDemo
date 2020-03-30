using Microsoft.AspNetCore.Mvc;
using SignalrDotnetCoreApi.Database.Entities;

namespace SignalrDotnetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrapesController : ControllerBase
    {
        [HttpPut]
        public ActionResult<bool> AddGrape([FromBody] Grape grape)
        {
            var result = false;
            return Ok(result);
        }
    }
}