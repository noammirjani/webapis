using BookApi.Repositories;
using BookApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IBooksRepository), typeof(BooksRepository)); 
builder.Services.AddScoped<BookService>();
builder.Services.AddControllers(); 

var app = builder.Build();
app.MapControllers();

app.Run();
