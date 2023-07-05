using Application.BusinessLogic.Dokument.Commands.Delete;
using Application.BusinessLogic.Dokument.Commands.Save;
using Application.BusinessLogic.Dokument.Queries;
using Application.BusinessLogic.Dokument.Queries.GetAllByUdruzenjeID;
using Application.BusinessLogic.Dokument.Queries.GetByID;
using Application.Common.Infrastructure.Settings;
using Application.Common.Interfaces;
using Application.Common.Models.Respones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    //[Authorize]
    public class DokumentController : ApiBaseController
    {
        public readonly IApplicationDbContext _context;
        //public DokumentPolicy _policy;

        public DokumentController(IOptions<AppSettings> appSettings, IApplicationDbContext context) : base(appSettings)
        {
            _context = context;
            //  _policy = policy;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Dokument" })]
        public async Task<ActionResult<int>> Save(SaveDokumentCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Dokument" })]
        public async Task<ActionResult<PagedResponse<DokumentViewModel>>> GetAll(GetAllDokumentByUdruzenjeIDQuery data)
        {
            return Ok(await Mediator.Send(data));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Dokument" })]
        public async Task<ActionResult<DokumentViewModel>> GetById(int id)
        {
            var result = await Mediator.Send(new GetDokumentByIDQuery { Id = id });

            if (result.IsError)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }

        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "Dokument" })]
        public async Task<ActionResult<int>> Delete(DeleteDokumentCommand request)
        {
            //if (!await _policy.CanDeleteAsync(User, request.Id))
            //    return BadRequest("Not authorized!");

            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Dokument" })]
        public async Task<ActionResult<string>> Download(int id) {
            var dokument = await Mediator.Send(new GetDokumentByIDQuery { Id = id });
            
            try
            {
                var Base64Datoteke = GetFileAsBase64(dokument.Result.GuidDatoteke, dokument.Result.EkstenzijaDatoteke);
                return Ok(Base64Datoteke);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }
    }
}

