using Application.BusinessLogic.AdministrativnaJedinica.Commands.CreateAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Commands.DeleteAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Queries.GetForDropdown;
using Application.BusinessLogic.Datoteka.Commands;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetTipAdministrativneJediniceById;
using Application.BusinessLogic.TipObjave.Commands.UpdateTipObjaveCommand;
using Application.BusinessLogic.Udruzenje.Commands.Create;
using Application.BusinessLogic.Udruzenje.Commands.Delete;
using Application.BusinessLogic.Udruzenje.Commands.Update;
using Application.BusinessLogic.Udruzenje.Queries.GetForDropdown;
using Application.BusinessLogic.Udruzenje.Queries.GetUdruzenjeByID;
using Application.Common.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Controllers
{
    [Authorize]
    public class UdruzenjeController : ApiBaseController
    {
        public UdruzenjeController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Udruzenje" })]

        public async Task<ActionResult<UdruzenjeViewModel>> GetById(int id)
        {
            var result = await Mediator.Send(new GetUdruzenjeByIDQuery { Id = id });

            if (result.IsError)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Udruzenje" })]
        public async Task<ActionResult<int>> Add(CreateUdruzenjeCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [AllowAnonymous]
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Udruzenje" })]
        public async Task<ActionResult<int>> Update(UpdateUdruzenjeCommand request)
        {
            if (request.LogoDatotekaId == 0)
            {
                if (request.NazivLogoDatoteke != null && request.Base64Logo != null)
                {
                    string[] nameAndExtension = request.NazivLogoDatoteke.Split(".");

                    var datotekaId = await Mediator.Send(new CreateDatotekaCommand
                    {
                        Naziv = nameAndExtension[0],
                        GuidDatoteke = Guid.NewGuid(),
                        Ekstenzija = nameAndExtension[1],
                        Base64Logo = request.Base64Logo,
                        Aktivno = true
                    });

                    request.LogoDatotekaId = datotekaId;
                }
            }
            else { 
                //TODO Update datoteke
            }

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
