using Application.BusinessLogic.AdministrativnaJedinica.Commands.CreateAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Commands.DeleteAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Queries;
using Application.BusinessLogic.AdministrativnaJedinica.Queries.GetById;
using Application.BusinessLogic.AdministrativnaJedinica.Queries.GetForDropdown;
using Application.BusinessLogic.TipAdministrativneJedinice.Commands.CreateTipAdministrativneJediniceCommand;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries;
using Application.Common.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Authorize]
    public class AdministrativnaJedinicaController : ApiBaseController
    {
        public AdministrativnaJedinicaController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "AdministrativnaJedinica" })]
        public async Task<ActionResult<List<int>>> Add(CreateAdministrativnaJedinicaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [AllowAnonymous]
        [HttpDelete]
        [SwaggerOperation(Tags = new[] {"AdministrativnaJedinica"})]
        public async Task<ActionResult<int>> Delete(DeleteAdministrativnaJedinicaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "AdministrativnaJedinica" })]

        public async Task<ActionResult<AdministrativnaJedinicaViewModel>> GetAdministrativnaJedinica(int id)
        {
            return Ok(await Mediator.Send(new GetAdministrativnaJedinicaByIdQuery { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "AdministrativnaJedinica" })]
        public async Task<ActionResult<List<AdmJedinicaDropdownViewModel>>> ForDropdown(int id)
        {
            return Ok(await Mediator.Send(new GetAdmJediniceForDropdownQuery { Id = id }));
        }

    }
}
