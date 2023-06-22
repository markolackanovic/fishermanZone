using Application.Authentification;
using Application.BusinessLogic.GetObjava.Queries.GetObjavaByID;
using Application.BusinessLogic.Objava.Commands.CreateObjava;
using Application.BusinessLogic.Objava.Commands.DeleteObjava;
using Application.BusinessLogic.Objava.Commands.UpdateObjava;
using Application.BusinessLogic.Objava.Policy;
using Application.BusinessLogic.Objava.Queries.GetAllQuery;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetAllQuery;
using Application.BusinessLogic.TipObjave.Queries.GetTipObjaveById;
using Application.Common.Infrastructure.Settings;
using Application.Common.Interfaces;
using Application.Common.Models.Respones;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace WebApi.Controllers
{
    public class ObjavaController : ApiBaseController
    {
        public readonly IApplicationDbContext _context;
        public ObjavaPolicy _policy;
        public ObjavaController(IOptions<AppSettings> appSettings,IApplicationDbContext context,ObjavaPolicy policy) : base(appSettings)
        {
            _context = context;
            _policy = policy;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Objava" })]
        public async Task<ActionResult<List<int>>> Add(CreateObjavaCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "Objava" })]
        public async Task<ActionResult<int>> Delete(DeleteObjavaCommand request)
        {
            if (!await _policy.CanDeleteAsync(User, request.Id))
                return BadRequest("Not authorized!");

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
            var result = await Mediator.Send(new GetObjavaByIdQuery { Id = id });

            if (result.IsError)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Objava" })]
        public async Task<ActionResult<PagedResponse<GetAllObjavaViewModel>>> GetAll(GetAllObjavaQuery data)
        {
            return Ok(await Mediator.Send(data));
        }
    }
}
