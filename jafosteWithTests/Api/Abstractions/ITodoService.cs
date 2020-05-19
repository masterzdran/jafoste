using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace API.Abstractions
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<TodoItem> GetTodoItem(long id);
        void PutTodoItem(long id, TodoItem todoItem);
        void PostTodoItem(TodoItem todoItem);
        void DeleteTodoItem(long id);
    }
}