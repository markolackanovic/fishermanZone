using Application.BusinessLogic.AdministrativnaJedinica.Commands.CreateAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Commands.DeleteAdministrativnaJedinicaCommand;
using Application.BusinessLogic.TipAdministrativneJedinice.Commands.CreateTipAdministrativneJediniceCommand;
using Application.BusinessLogic.TipAdministrativneJedinice.Commands.DeleteTipAdministrativneJediniceCommand;
using Application.BusinessLogic.TipAdministrativneJedinice.Commands.UpdateTipAdministrativneJediniceCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Authorize]
    public class TipAdministrativneJediniceController : ApiBaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "TipAdministrativneJedinice" })]
        public async Task<ActionResult<List<int>>> Add(CreateTipAdministrativneJediniceCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "AdministrativnaJedinica" })]
        public async Task<ActionResult<int>> Delete(DeleteTipAdministrativneJediniceCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "AdministrativnaJedinica" })]
        public async Task<ActionResult<int>> Update(UpdateTipAdministrativneJediniceCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

    }
}
