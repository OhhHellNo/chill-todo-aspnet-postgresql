using Chill_Todo_API.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace Chill_Todo_API.Data;

public class TodoDbContext:DbContext
{
    TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }
    public DbSet<Todo> Todos { get; set; }
}