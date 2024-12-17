using TodoListAPI.Models;

namespace TodoListAPI.Services;

public interface ITodoService
{
    IEnumerable<TodoItem> GetAll();
    void Add(TodoItem item);
    void MarkAsCompleted(int id);
    void Delete(int id);
}
