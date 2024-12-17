// using TodoListAPI.Models;
// using TodoListAPI.Repositories;
// using TodoListAPI.Services;
// using Xunit;

// namespace TodoListAPI.Tests;

// public class TodoServiceTests
// {
//     private readonly ITodoService _service;

//     public TodoServiceTests()
//     {
//         var repository = new InMemoryTodoRepository();
//         _service = new TodoService(repository);
//     }

//     [Fact]
//     public void Add_ShouldThrowException_WhenTitleIsEmpty()
//     {
//         var item = new TodoItem { Id = 1, Title = "" };

//         var exception = Assert.Throws<ArgumentException>(() => _service.Add(item));
//         Assert.Equal("Title cannot be empty.", exception.Message);
//     }

//     [Fact]
//     public void Add_ShouldThrowException_WhenMoreThan10Items()
//     {
//         for (int i = 1; i <= 10; i++)
//             _service.Add(new TodoItem { Id = i, Title = $"Todo {i}" });

//         var item = new TodoItem { Id = 11, Title = "Exceeding Limit" };

//         var exception = Assert.Throws<InvalidOperationException>(() => _service.Add(item));
//         Assert.Equal("Cannot add more than 10 todo items.", exception.Message);
//     }
// }
