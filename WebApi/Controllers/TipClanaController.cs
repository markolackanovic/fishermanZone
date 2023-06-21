using Application.BusinessLogic.GetTipClana.Queries.GetTipClanaByID;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries;
using Application.BusinessLogic.TipClana.Commands.CreateTipClanaCommand;
using Application.BusinessLogic.TipClana.Commands.DeleteTipClanaCommand;
using Application.BusinessLogic.TipClana.Commands.UpdateTipClanaCommand;
using Application.BusinessLogic.TipObjave.Queries.GetTipObjaveById;
using Application.Common.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    public class TipClanaController : ApiBaseController
    {
        public TipClanaController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

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
            var result = await Mediator.Send(new GetTipClanaByIdQuery { Id = id });

            if (result.IsError)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }
    }
}
