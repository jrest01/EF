using EntityFramework.models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class ProjectContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<models.Task> Tasks { get; set; }

    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
}