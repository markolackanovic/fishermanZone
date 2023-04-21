using Application.BusinessLogic.Roles.Commands;
using Application.BusinessLogic.TodoItems___Example.Commands.CreateTodoItem;
using Application.BusinessLogic.TodoItems___Example.Queries.GetTodoItemsWithPagination;
using Application.Common.Models.Respones;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]

    public class RolesController : ApiBaseController
    {
       
        

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> Create(CreateRolesCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command);
        }


    }
}