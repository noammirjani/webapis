using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models;
using TodoListAPI.Services;

namespace TodoListAPI.Controllers;


/// Controller for managing Todo items.
[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoController(ITodoService service)
    {
        _service = service;
    }

    /// Get all Todo items.
    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());


    /// Add a new Todo item.
    [HttpPost]
    public IActionResult Add(TodoItem item)
    {
        try
        {
            _service.Add(item);
            return CreatedAtAction(nameof(GetAll), null);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }


    /// Mark a Todo item as completed.
    [HttpPut("{id}/complete")]
    public IActionResult MarkAsCompleted(int id)
    {
        _service.MarkAsCompleted(id);
        return NoContent();
    }


    /// Delete a Todo item.
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}
