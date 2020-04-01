using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalrDotnetCoreApi.Database.Entities;
using SignalrDotnetCoreApi.Repository.UnitOfWork;

namespace SignalrDotnetCoreApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GrapesController : ControllerBase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GrapesController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        [HttpPut]
        [Route("Add")]
        public async ValueTask<ActionResult> Add([FromBody] Grape grape)
        {
            using var uow = _unitOfWorkFactory.Create();
            var repo = uow.GetRepository<Grape>();
            await repo.AddAsync(grape);
            await uow.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("Grapes")]
        public async Task<ActionResult<List<Grape>>> Grapes()
        {
            using var uow = _unitOfWorkFactory.Create();
            var repo = uow.GetRepository<Grape>();
            var result = await repo.GetAllAsync();

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            using var uow = _unitOfWorkFactory.Create();
            var repo = uow.GetRepository<Grape>();
            var item = await repo.Where(x => x.Id == id).FirstAsync();
            repo.Remove(item);
            await uow.SaveChangesAsync();

            return Ok();
        }
    }
}