using WebApiDemo.Models;
using WebApiDemo.ViewModels;

namespace WebApplication1.Services
{
    public interface ITodoService
    {

        Task<List<TodoEntry>> GetAll();
        Task<List<TodoEntry>> FilterByName(string name);
        Task<TodoEntry?> GetById(Guid id);
        Task<bool> AddTodo(TodoEntry entry);
        Task<bool> RemoveTodo(Guid id);
        Task<bool> UpdateTodo(Guid id, TodoEntryViewModel entry);
        //Task<bool> UpdateDueDate(DateTime date);
    }
}
