using Application.TodoILists.Commands.DeleteTodoList;
using Application.TodoILists.Commands.UpdateTodoList;
using Application.TodoILists.Queries;
using Application.TodoLists.Commands.CreateTodoList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ToDo.Api.Controllers.TodoList
{
    [Authorize]
    public class TodoListsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTodoListsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id ,UpdateTodoListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTodoListCommand { Id = id }));
        }
    }
}