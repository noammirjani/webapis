using TodoListAPI.Models;
using TodoListAPI.Repositories;

namespace TodoListAPI.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<TodoItem> GetAll() => _repository.GetAll();

    public void Add(TodoItem item)
    {
        if (string.IsNullOrWhiteSpace(item.Title))
            throw new ArgumentException("Title cannot be empty.");

        if (_repository.GetAll().Count() >= 10)
            throw new InvalidOperationException("Cannot add more than 10 todo items.");

        _repository.Add(item);
    }

    public void MarkAsCompleted(int id) => _repository.MarkAsCompleted(id);

    public void Delete(int id) => _repository.Delete(id);
}
