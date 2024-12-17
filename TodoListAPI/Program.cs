using TodoListAPI.Repositories;
using TodoListAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();
services.AddScoped<ITodoService, TodoService>();

services.AddControllers();
services.AddEndpointsApiExplorer();


var app = builder.Build();


app.UseAuthorization();
app.MapControllers();
app.Run();
