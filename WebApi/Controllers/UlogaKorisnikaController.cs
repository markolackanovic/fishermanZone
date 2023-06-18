using Application.BusinessLogic.UlogaKorisnika.Commands.CreateUlogaKorisnikaCommand;
using Application.BusinessLogic.UlogaKorisnika.Commands.DeleteUlogaKorisnikaCommand;
using Application.BusinessLogic.UlogaKorisnika.Commands.UpdateUlogaKorisnikaCommand;
using Application.BusinessLogic.UlogaKorisnika.Queries.GetUlogaKorisnikaByID;
using Application.Common.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    public class UlogaKorisnikaController : ApiBaseController
    {
        public UlogaKorisnikaController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "UlogaKorisnika" })]
        public async Task<ActionResult<List<int>>> Add(CreateUlogaKorisnikaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "UlogaKorisnika" })]
        public async Task<ActionResult<int>> Delete(DeleteUlogaKorisnikaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "UlogaKorisnika" })]
        public async Task<ActionResult<int>> Update(UpdateUlogaKorisnikaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "UlogaKorisnika" })]

        public async Task<ActionResult<UlogaKorisnikaViewModel>> GetUlogaKorisnikaById(int id)
        {
            return Ok(await Mediator.Send(new GetUlogaKorisnikaByIdQuery { Id = id }));
        }
    }
}

