using TodoListAPI.Models;

namespace TodoListAPI.Repositories;

public interface ITodoRepository
{
    IEnumerable<TodoItem> GetAll();
    void Add(TodoItem item);
    void MarkAsCompleted(int id);
    void Delete(int id);
}
