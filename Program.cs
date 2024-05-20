using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Creates a DB InMemory to validate the operation
//builder.Services.AddDbContext<ProjectContext>(p => p.UseInMemoryDatabase("TasksDB"));

//Connecting with PostgreSQL
var Configuration = builder.Configuration;
builder.Services.AddDbContext<ProjectContext>(options => options.UseNpgsql(
    Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] ProjectContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database on Memory: " + dbContext.Database.IsInMemory());
});


app.Run();
