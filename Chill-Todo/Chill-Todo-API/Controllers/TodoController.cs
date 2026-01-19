using Chill_Todo_API.Data;
using Chill_Todo_API.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chill_Todo_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoDbContext _dbContext;

    public TodoController(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetTodos()
    {
        var todos = _dbContext.Todos.ToList();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    public IActionResult GetTodo(Guid id)
    {
        var todo = _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpPost]
    public IActionResult AddTodo([FromBody] Todo todo)
    {
        var title = todo.Title;
        var isCompleted = todo.isCompleted;
        var description = todo.Description;

        _dbContext.Todos.Add(todo);
        _dbContext.SaveChanges();
        return Ok(todo);
    }
}