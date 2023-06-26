using Application.BusinessLogic.AdministrativnaJedinica.Commands.CreateAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Commands.DeleteAdministrativnaJedinicaCommand;
using Application.BusinessLogic.AdministrativnaJedinica.Queries.GetForDropdown;
using Application.BusinessLogic.Datoteka.Commands;
using Application.BusinessLogic.Datoteka.Commands.Create;
using Application.BusinessLogic.Datoteka.Commands.Delete;
using Application.BusinessLogic.Datoteka.Commands.Update;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetTipAdministrativneJediniceById;
using Application.BusinessLogic.TipDatoteke.Queries.GetTipDatotekeById;
using Application.BusinessLogic.TipObjave.Commands.UpdateTipObjaveCommand;
using Application.BusinessLogic.Udruzenje.Commands.Create;
using Application.BusinessLogic.Udruzenje.Commands.Delete;
using Application.BusinessLogic.Udruzenje.Commands.Update;
using Application.BusinessLogic.Udruzenje.Queries.GetForDropdown;
using Application.BusinessLogic.Udruzenje.Queries.GetUdruzenjeByID;
using Application.Common.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Controllers
{
    [Authorize]
    public class UdruzenjeController : ApiBaseController
    {
        public UdruzenjeController(IOptions<AppSettings> appSettings) : base(appSettings){ }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Udruzenje" })]

        public async Task<ActionResult<UdruzenjeViewModel>> GetById(int id)
        {
            var result = await Mediator.Send(new GetUdruzenjeByIDQuery { Id = id });

            if (!result.IsError)
            {
                //var path = Path.Combine(_appSettings.Value.ImagesFolder, guidFileName);
                var path = Path.Combine("C:\\Users\\pero.novakovic\\test", result.Result.GuidLogoDatoteke + "." + result.Result.EkstenzijaLogoDatoteke);
                if (System.IO.File.Exists(path))
                {
                    try
                    {
                        Byte[] bytes = System.IO.File.ReadAllBytes(path);
                        result.Result.Base64LogoDatoteke = "data:image/" + result.Result.EkstenzijaLogoDatoteke + ";base64," + Convert.ToBase64String(bytes);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.InnerException);
                    }
                }
            }
            else {
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
            //Datoteka bila, ali je obrisana
            if (request.LogoDatotekaID != null && request.NazivLogoDatoteke == null && request.Base64Logo == null) {
                await Mediator.Send(new DeleteDatotekaCommand { Id = (int)request.LogoDatotekaID });

                request.LogoDatotekaID = null;
            }
            //Nije bilo datoteke, tek dodana
            else if (request.LogoDatotekaID == null && request.NazivLogoDatoteke != null && request.Base64Logo != null)
            {
                Guid guid = Guid.NewGuid();
                string[] filenameAndExtension = request.NazivLogoDatoteke.Split(".");
                    
                var datotekaId = await Mediator.Send(new CreateDatotekaCommand
                {
                    Naziv = filenameAndExtension[0],
                    Guid = guid.ToString(),
                    Ekstenzija = filenameAndExtension[1],
                    Aktivno = true,
                    TipDatotekeId = 1
                });

                try
                {
                    WriteFileToDisk(guid.ToString() + "." + filenameAndExtension[1], request.Base64Logo);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                request.LogoDatotekaID = datotekaId;
            }
            //Promijenjena datoteka
            else if(request.LogoDatotekaID != null && request.NazivLogoDatoteke != null && request.Base64Logo != null)
            {
                string[] nameAndExtension = request.NazivLogoDatoteke.Split(".");

                await Mediator.Send(new UpdateDatotekaCommand
                {
                    DatotekaId = (int)request.LogoDatotekaID,
                    Naziv = nameAndExtension[0],
                    Ekstenzija = nameAndExtension[1],
                    Guid = request.GuidLogoDatoteke,
                    TipDatotekeId = 1
                });

                try
                {
                    WriteFileToDisk(request.GuidLogoDatoteke.ToString() + "." + nameAndExtension[1], request.Base64Logo);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
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
