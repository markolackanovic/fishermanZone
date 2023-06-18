using Application.BusinessLogic.AdministrativnaJedinica.Commands.CreateAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Commands.DeleteAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Queries.GetForDropdown;
using Application.BusinessLogic.Udruzenje.Commands.Create;
using Application.BusinessLogic.Udruzenje.Commands.Delete;
using Application.BusinessLogic.Udruzenje.Queries.GetForDropdown;
using Application.Common.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Authorize]
    public class UdruzenjeController : ApiBaseController
    {
        public UdruzenjeController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Udruzenje" })]
        public async Task<ActionResult<int>> Add(CreateUdruzenjeCommand request)
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

        [AllowAnonymous]
        [HttpGet("{id}/{nadredjenoUdruzenjeId}")]
        [SwaggerOperation(Tags = new[] { "Udruzenje" })]
        public async Task<ActionResult<List<UdruzenjeDropdownViewModel>>> ForDropdown(int id, int nadredjenoUdruzenjeId)
        {
            return Ok(await Mediator.Send(new GetUdruzenjeForDropdownQuery { Id = id, NadredjenoUdruzenjeId = nadredjenoUdruzenjeId }));
        }
    }
}
