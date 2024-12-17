using TodoListAPI.Models;

namespace TodoListAPI.Repositories;

public class InMemoryTodoRepository : ITodoRepository
{
    private readonly List<TodoItem> _todos = new();
    private int _currentId = 1;

    public IEnumerable<TodoItem> GetAll() => _todos;

    public void Add(TodoItem item)
    {
        if (_todos.Any(t => t.Id == item.Id))
            throw new ArgumentException("A todo item with the same Id already exists.");

        // Automatically assign a unique ID if none is provided
        if (item.Id == 0)
            item.Id = _currentId++;

        _todos.Add(item);
    }

    public void MarkAsCompleted(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null) todo.IsCompleted = true;
    }

    public void Delete(int id) => _todos.RemoveAll(t => t.Id == id);
}
