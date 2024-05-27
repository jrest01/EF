using EntityFramework;
using EntityFramework.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

//ProjectContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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

app.MapGet("/api/tasks", async ([FromServices] ProjectContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(p => p.Category).Where(p => p.TaskPriority == Priority.High));
});

app.MapPost("/api/tasks", async ([FromServices] ProjectContext dbContext, [FromBody] EntityFramework.models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.Date = DateTime.UtcNow;
    await dbContext.AddAsync(task);
    // await dbContext.Tasks.AddAsync(task);

    await dbContext.SaveChangesAsync();
    return Results.Ok();
});


app.MapPut("/api/tasks/{id}", async ([FromServices] ProjectContext dbContext, [FromBody] EntityFramework.models.Task task, [FromRoute] Guid id) =>
{
    var actualTask = dbContext.Tasks.Find(id);
    if (actualTask != null)
    {
        actualTask.CategoryId = task.CategoryId;
        actualTask.Title = task.Title;
        actualTask.TaskPriority = task.TaskPriority;
        actualTask.Description = task.Description;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }
    return Results.NotFound();
});


app.MapDelete("/api/tasks/{id}", async ([FromServices] ProjectContext dbContext, [FromRoute] Guid id) =>
{
    var actualTask = dbContext.Tasks.Find(id);
    if (actualTask != null)
    {
        dbContext.Tasks.Remove(actualTask);
        // await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});


app.Run();
