using Microsoft.AspNetCore.Mvc;
using WebApiDemo.ViewModels;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private static List<TodoEntry> todoEntries = new();
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult List()
        {
            return Ok(todoEntries);
        }

        [HttpGet("filter")]
        public ActionResult Search([FromQuery] string name)
        {
            return Ok(todoEntries
                .Where(todo => todo.Title.Contains(name))
                .ToList());
        }

        [HttpPost]
        public ActionResult Add([FromBody] TodoEntryViewModel entry)
        {
            var newTodoEntry = new TodoEntry(entry.Title, entry.Description, entry.DueDate);

            if (todoEntries.Any(existingTodo => existingTodo.Id == newTodoEntry.Id))
            {
                return Conflict("Duplicated Todo Id");
            }

            todoEntries.Add(newTodoEntry);
            return Created($"/{newTodoEntry.Id}", entry);
        }

        [HttpDelete("delete")]
        public ActionResult Remove([FromRoute] Guid todoId)
        {
            //throw new NotImplementedException();
            TodoEntry removeTodo = todoEntries.Find(i => i.Id.Equals(todoId));
            if (removeTodo == null)
            {
                return NotFound("To Do ID is not found.");
            }
            else
            {
                todoEntries.Remove(removeTodo);
                return Ok("This ID has been removed!");
            }
        }

        [HttpPut("update")]
        public ActionResult Replace([FromRoute] Guid todoId, [FromBody] TodoEntryViewModel entry)
        {
            //throw new NotImplementedException();
            TodoEntry updateTodo = todoEntries.Find(i => i.Id.Equals(todoId));
            if (updateTodo == null)
            {
                return NotFound("To Do ID is not found.");
            }
            else
            {
                updateTodo.Title = entry.Title;
                updateTodo.Description = entry.Description;
                updateTodo.DueDate = entry.DueDate;
                return Ok("This ID has been updated successfully!");
            }
        }
    }
}
