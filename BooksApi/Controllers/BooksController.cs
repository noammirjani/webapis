using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookService _service; 


    public BooksController(BookService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll()); 

    [HttpPost]
    public IActionResult Add([FromBody] Book bookToAdd){
        try
        {
        _service.Add(bookToAdd);
        return CreatedAtAction(nameof(GetAll), null);
        }
        catch (Exception ex){
            return BadRequest( new {Message = ex.Message});
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] Book bookToUpdate){
        _service.Update(bookToUpdate);
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        _service.Delete(id);
        return NoContent(); 
    }
}