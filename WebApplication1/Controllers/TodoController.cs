using Microsoft.AspNetCore.Mvc;
using WebApiDemo.ViewModels;
using WebApiDemo.Models;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly ILogger<TodoController> _logger;
        private readonly WebApiDemoContext? _context;
        private readonly ITodoService _todoService;

        // private readonly string? userId;

        public TodoController(ILogger<TodoController> logger, WebApiDemoContext context, ITodoService todoService)
        {
            _logger = logger;
            // _context = context;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return Ok(await _todoService.GetAll());
        }

        [HttpGet("filter")]
        public async Task<ActionResult> Search([FromQuery] string name)
        {
            return Ok(await _todoService.FilterByName(name));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TodoEntryViewModel entry)
        {
            var todoEntry = new TodoEntry(entry.Title, entry.Description, entry.DueDate);

            if (await _todoService.AddTodo(todoEntry))
            {
                return Created($"/{todoEntry.Id}", entry);
            }
            else
            {
                return BadRequest("Failed to add todo entry.");
            }
        }

        [HttpDelete("{todoId}")]
        public async Task<ActionResult> Remove([FromRoute] Guid todoId)
        {
            var isSuccess = await _todoService.RemoveTodo(todoId);

            if (isSuccess)
            {
                return Ok($"Removed todo with ID: {todoId}");
            }
            else
            {
                return NotFound("Todo entry not found");
            }
        }

        [HttpPut("{todoId}")]
        public async Task<ActionResult> Replace([FromRoute] Guid todoId, [FromBody] TodoEntryViewModel entry)
        {
            var isSuccess = await _todoService.UpdateTodo(todoId, entry);

            if (!isSuccess)
            {
                return NotFound("Todo entry not found");
            }

            return Ok($"Updated todo with ID: {todoId}");
        }

    }
}
//    public class TodoController : ControllerBase
//    {

//        private readonly ILogger<TodoController> _logger;
//        private readonly WebApiDemoContext _context;
//        private readonly ITodoService _todoService;

//        public TodoController(ILogger<TodoController> logger, WebApiDemoContext context, ITodoService todoService)
//        {
//            _logger = logger;
//            //_context = context;
//            _todoService = todoService;
//        }

//        [HttpGet]
//        public async Task <ActionResult> List()
//        {
//            return Ok(await _todoService.GetAll());
//        }

//        [HttpGet("filter")]
//        public async Task<ActionResult> Search([FromQuery] string name)
//        {
//            //return Ok(_context.TodoEntries
//            //    .Where(todo => todo.Title.Contains(name))
//            //    .ToList());
//            return Ok(await _todoService.FilterByName(name));
//        }

//        [HttpPost]
//        public ActionResult Add([FromBody] TodoEntryViewModel entry)
//        {
//            var newTodoEntry = new TodoEntry(entry.Title, entry.Description, entry.DueDate);

//            if (_context.TodoEntries.Any(existingTodo => existingTodo.Id == newTodoEntry.Id))
//            {
//                return Conflict("Duplicated Todo Id");
//            }

//            _context.TodoEntries.Add(newTodoEntry);
//            _context.SaveChanges();
//            return Created($"/{newTodoEntry.Id}", entry);
//        }

//        [HttpDelete("delete")]
//        public ActionResult Remove([FromRoute] Guid todoId)
//        {
//            //throw new NotImplementedException();
//            TodoEntry? removeTodo = _context.TodoEntries.FirstOrDefault(i => i.Id.Equals(todoId));
//            if (removeTodo == null)
//            {
//                return NotFound("To Do ID is not found.");
//            }
//            else
//            {
//                _context.TodoEntries.Remove(removeTodo);
//                return Ok("This ID has been removed!");
//            }
//        }

//        [HttpPut("update")]
//        public ActionResult Replace([FromRoute] Guid todoId, [FromBody] TodoEntryViewModel entry)
//        {
//            //throw new NotImplementedException();
//            TodoEntry? updateTodo = _context.TodoEntries.FirstOrDefault(i => i.Id.Equals(todoId));
//            if (updateTodo == null)
//            {
//                return NotFound("To Do ID is not found.");
//            }
//            else
//            {
//                updateTodo.Title = entry.Title;
//                updateTodo.Description = entry.Description;
//                updateTodo.DueDate = entry.DueDate;
//                return Ok("This ID has been updated successfully!");
//            }
//        }
//    }
//}
