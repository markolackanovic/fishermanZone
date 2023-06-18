using Application.Authentification;
using Application.BusinessLogic.GetObjava.Queries.GetObjavaByID;
using Application.BusinessLogic.Objava.Commands.CreateObjava;
using Application.BusinessLogic.Objava.Commands.DeleteObjava;
using Application.BusinessLogic.Objava.Commands.UpdateObjava;
using Application.BusinessLogic.Objava.Queries.GetAllQuery;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetAllQuery;
using Application.Common.Models.Respones;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ObjavaController : ApiBaseController
    {
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Objava" })]
        [HasPermission(Permission.ReadMember)]
        public async Task<ActionResult<List<int>>> Add(CreateObjavaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "Objava" })]
        public async Task<ActionResult<int>> Delete(DeleteObjavaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Objava" })]
        public async Task<ActionResult<int>> Update(UpdateObjavaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Objava" })]

        public async Task<ActionResult<ObjavaViewModel>> GetObjavaById(int id)
        {
            return Ok(await Mediator.Send(new GetObjavaByIdQuery { Id = id }));
        }
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Objava" })]
        public async Task<ActionResult<PagedResponse<GetAllObjavaViewModel>>> GetAll(GetAllObjavaQuery data)
        {
            return Ok(await Mediator.Send(data));
        }
    }
}
