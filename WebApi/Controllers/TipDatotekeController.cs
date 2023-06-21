using Application.BusinessLogic.TipDatoteke.Commands.CreateTipDatotekeCommand;
using Application.BusinessLogic.TipDatoteke.Commands.DeleteTipDatotekeCommand;
using Application.BusinessLogic.TipDatoteke.Commands.UpdateTipDatotekeCommand;
using Application.BusinessLogic.TipDatoteke.Queries.GetTipDatotekeById;
using Application.BusinessLogic.TipDatoteke.Queries.SearchTipDatoteke;
using Application.BusinessLogic.TipObjave.Queries.GetTipObjaveById;
using Application.Common.Infrastructure.Settings;
using Application.Common.Models.Respones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Authorize]
    public class TipDatotekeController : ApiBaseController
    {
        public TipDatotekeController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "TipDatoteke" })]
        public async Task<ActionResult<List<int>>> Add(CreateTipDatotekeCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "TipDatoteke" })]
        public async Task<ActionResult<int>> Delete(DeleteTipDatotekeCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "TipDatoteke" })]
        public async Task<ActionResult<int>> Update(UpdateTipDatotekeCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "TipDatoteke" })]

        public async Task<ActionResult<TipDatotekeViewModel>> GetTipDatotekeById(int id)
        {
            var result = await Mediator.Send(new GetTipDatotekeByIdQuery { Id = id });

            if (result.IsError)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }
        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "TipDatoteke" })]
        public async Task<ActionResult<PagedResponse<SearchTipDatotekeViewModel>>> SearchTipDatoteke(SearchTipDatotekeQuery data)
        {
            return Ok(await Mediator.Send(data));
        }

    }
}
