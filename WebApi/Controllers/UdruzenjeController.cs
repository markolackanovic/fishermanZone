using Application.BusinessLogic;
using Application.BusinessLogic.AdministrativnaJedinica.Commands.CreateAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Commands.DeleteAdministrativnaJedinicaCommand;
using Application.BusinessLogic.Udruzenje.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Authorize]
    public class UdruzenjeController : ApiBaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Udruzenje" })]
        public async Task<ActionResult<List<int>>> Add(CreateUdruzenjeCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "Udruzenje" })]
        public async Task<ActionResult<List<int>>> Delete(DeleteUdruzenjeCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

    }
}
