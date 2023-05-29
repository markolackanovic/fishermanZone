﻿using Application.BusinessLogic.TipAdministrativneJedinice.Commands.CreateTipAdministrativneJediniceCommand;
using Application.BusinessLogic.TipAdministrativneJedinice.Commands.DeleteTipAdministrativneJediniceCommand;
using Application.BusinessLogic.TipAdministrativneJedinice.Commands.UpdateTipAdministrativneJediniceCommand;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetAllQuery;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetTipAdministrativneJediniceById;
using Application.BusinessLogic.TipAdministrativneJedinice.Queries.SearchTipAdministrativneJedinice;
using Application.Common.Models.Respones;
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
        [SwaggerOperation(Tags = new[] { "TipAdministrativneJedinice" })]
        public async Task<ActionResult<int>> Delete(DeleteTipAdministrativneJediniceCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "TipAdministrativneJedinice" })]
        public async Task<ActionResult<int>> Update(UpdateTipAdministrativneJediniceCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "TipAdministrativneJedinice" })]

        public async Task<ActionResult<TipAdministrativneJediniceViewModel>> GetTipAdministrativneJediniceById(int id)
        {
            return Ok(await Mediator.Send(new GetTipAdministrativneJediniceByIdQuery { Id = id }));
        }
        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "TipAdministrativneJedinice" })]
        public async Task<ActionResult<PagedResponse<SearchTipAdministrativneJediniceViewModel>>> SearchTipAdministrativneJedinice(SearchTipAdministrativneJediniceQuery data)
        {
            return Ok(await Mediator.Send(data));
        }
        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "TipAdministrativneJedinice" })]
        public async Task<ActionResult<PagedResponse<GetAllTipAdministrativneJediniceViewModel>>> GetAll(GetAllTipAdministrativneJediniceQuery data)
        {
            return Ok(await Mediator.Send(data));
        }

    }
}
