using Application.BusinessLogic.GetTipClana.Queries.GetTipClanaByID;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries;
using Application.BusinessLogic.TipClana.Commands.CreateTipClanaCommand;
using Application.BusinessLogic.TipClana.Commands.DeleteTipClanaCommand;
using Application.BusinessLogic.TipClana.Commands.UpdateTipClanaCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    public class TipClanaController : ApiBaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "TipClana" })]
        public async Task<ActionResult<List<int>>> Add(CreateTipClanaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "TipClana" })]
        public async Task<ActionResult<int>> Delete(DeleteTipClanaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "TipClana" })]
        public async Task<ActionResult<int>> Update(UpdateTipClanaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "TipClana" })]

        public async Task<ActionResult<TipClanaViewModel>> GetTipClanaById(int id)
        {
            return Ok(await Mediator.Send(new GetTipClanaByIdQuery { Id = id }));
        }
    }
}
