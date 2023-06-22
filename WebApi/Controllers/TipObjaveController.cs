using Application.BusinessLogic.TipObjave.Commands.CreateTipObjaveCommand;
using Application.BusinessLogic.TipObjave.Commands.DeleteTipObjaveCommand;
using Application.BusinessLogic.TipObjave.Commands.UpdateTipObjaveCommand;
using Application.BusinessLogic.TipObjave.Queries.GetTipObjaveById;
using Application.BusinessLogic.TipObjave.Queries.SearchTipObjave;
using Application.Common.Infrastructure.Settings;
using Application.Common.Models.Respones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Authorize]
    public class TipObjaveController : ApiBaseController
    {
        public TipObjaveController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "TipObjave" })]
        public async Task<ActionResult<List<int>>> Add(CreateTipObjaveCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "TipObjave" })]
        public async Task<ActionResult<int>> Delete(DeleteTipObjaveCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "TipObjave" })]
        public async Task<ActionResult<int>> Update(UpdateTipObjaveCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "TipObjave" })]

        public async Task<ActionResult<TipObjaveViewModel>> GetTipObjaveById(int id)
        {

            var result =  await Mediator.Send(new GetTipObjaveByIdQuery { Id = id });

            if(result.IsError)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }
        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "TipObjave" })]
        public async Task<ActionResult<PagedResponse<SearchTipObjaveViewModel>>> SearchTipObjave(SearchTipObjaveQuery data)
        {
            return Ok(await Mediator.Send(data));
        }

    }
}
