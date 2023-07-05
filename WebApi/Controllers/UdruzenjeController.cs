using Application.BusinessLogic.Datoteka.Commands.Delete;
using Application.BusinessLogic.Datoteka.Commands.Save;
using Application.BusinessLogic.Udruzenje.Commands.Delete;
using Application.BusinessLogic.Udruzenje.Commands.Save;
using Application.BusinessLogic.Udruzenje.Queries.GetForDropdown;
using Application.BusinessLogic.Udruzenje.Queries.GetUdruzenjeByID;
using Application.Common.Infrastructure.Settings;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;
using System.Net.NetworkInformation;
using System;
using Domain.Entities;
using Application.BusinessLogic.Dokument.Commands.Delete;

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

            if (result.IsError)
            {
                return BadRequest(result.ErrorMessage);
            }

            try
            {
                result.Result.Base64LogoDatoteke = GetImageAsBase64(result.Result.GuidLogoDatoteke, result.Result.EkstenzijaLogoDatoteke);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Udruzenje" })]
        public async Task<ActionResult<int>> Save(SaveUdruzenjeCommand request)
        {
            //Novo udruženje
            if (request.UdruzenjeId == 0)
            {
                //Ako ima logo
                if (!string.IsNullOrEmpty(request.NazivLogoDatoteke) && !string.IsNullOrEmpty(request.Base64Logo))
                {
                    request.LogoDatotekaID = SaveDatoteka(0, request.NazivLogoDatoteke, Guid.NewGuid().ToString(), request.Base64Logo).Result.Value;
                }
            }
            //Update udruženja
            else
            {
                //Datoteka bila, ali je obrisana
                if (request.LogoDatotekaID != null && request.NazivLogoDatoteke == null && request.Base64Logo == null)
                {
                    await Mediator.Send(new DeleteDatotekaCommand { Id = (int)request.LogoDatotekaID });
                    request.LogoDatotekaID = null;
                }//Nije bilo datoteke, tek dodana
                else if (request.LogoDatotekaID == null && !string.IsNullOrEmpty(request.NazivLogoDatoteke) && !string.IsNullOrEmpty(request.Base64Logo))
                {
                    request.LogoDatotekaID = SaveDatoteka(0, request.NazivLogoDatoteke, Guid.NewGuid().ToString(), request.Base64Logo).Result.Value;
                }//Promijenjena datoteka
                else if (request.LogoDatotekaID != null && !string.IsNullOrEmpty(request.NazivLogoDatoteke) && !string.IsNullOrEmpty(request.GuidLogoDatoteke) && !string.IsNullOrEmpty(request.Base64Logo))
                {
                    await SaveDatoteka((int)request.LogoDatotekaID, request.NazivLogoDatoteke, request.GuidLogoDatoteke, request.Base64Logo);
                }
            }

            foreach (var dokument in request.Dokumenti)
            {
                if (dokument.Id == null || dokument.Id == 0)
                {
                    dokument.UdruzenjeId = request.UdruzenjeId;

                    int datotekaId = SaveDatoteka(dokument.DatotekaId, dokument.NazivDatoteke, Guid.NewGuid().ToString(), dokument.Base64Datoteke).Result.Value;

                    dokument.DatotekaId = datotekaId;
                    await Mediator.Send(dokument);
                }
            }

            foreach (var dokumentId in request.DokumentiZaBrisanje)
            {
                await Mediator.Send(new DeleteDokumentCommand { Id = dokumentId });
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

        private async Task<ActionResult<int>> SaveDatoteka(int datotekaId, string nazivDatoteke, string guidDatoteke, string base64Datoteke) {
            string[] filenameAndExtension = nazivDatoteke.Split(".");

            string guid = guidDatoteke == null ? Guid.NewGuid().ToString() : guidDatoteke.ToString();

           int newDatotekaId = await Mediator.Send(new SaveDatotekaCommand
            {
                Id = datotekaId,
                DatotekaId = datotekaId,
                Naziv = filenameAndExtension[0],
                Guid = guid,
                Ekstenzija = filenameAndExtension[1],
                Aktivno = true,
                TipDatotekeId = 1
            });

            try
            {
                WriteFileToDisk(guid + "." + filenameAndExtension[1], base64Datoteke);
            }catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            
            return newDatotekaId;
        }

        protected void WriteFileToDisk(string guidFileName, string fileBase64)
        {
            //var path = Path.Combine(_appSettings.Value.ImagesFolder, guidFileName);
            var path = Path.Combine("C:\\Users\\pero.novakovic\\test", guidFileName);
            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(fileBase64));
        }
    }
}
