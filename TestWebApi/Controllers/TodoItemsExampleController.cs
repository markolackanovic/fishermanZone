using Application.BusinessLogic.TodoItems___Example.Commands.CreateTodoItem;
using Application.BusinessLogic.TodoItems___Example.Queries.GetTodoItemsWithPagination;
using Application.Common.Models.Respones;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]

    public class TodoItemsExampleController : ApiBaseController
    {
        [HttpPost]

        public async Task<ActionResult<PagedResponse<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery request)
        {
            return await Mediator.Send(request);

        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
        {
            return await Mediator.Send(command);
        }


    }
}
