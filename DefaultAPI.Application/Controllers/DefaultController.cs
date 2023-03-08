using DefaultAPI.Domain.Commands.Default;
using DefaultAPI.Domain.Commands.Default.Queries;
using DefaultAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DefaultAPI.Application.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefaultController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => CreateResponse(await Mediator.Send(new DefaultClassQueries.FindAsyncQuerie(id)));

        [HttpGet]
        public async Task<IActionResult> Get() => CreateResponse(await Mediator.Send(new DefaultClassQueries.GetAllAsyncQuerie()));

        [HttpPost]
        public async Task<IActionResult> Post(DefaultClassCreateCommand command) => CreateResponse(await Mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DefaultClassUpdateCommand command) => CreateResponse(await Mediator.Send(command));
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => CreateResponse(await Mediator.Send(new DefaultClassDeleteCommand(id)));
    }
}