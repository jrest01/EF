using EntityFramework.models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class ProjectContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<models.Task> Tasks { get; set; }

    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.Name).IsRequired().HasMaxLength(100);
            category.Property(p => p.Description);
        });

        modelBuilder.Entity<models.Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);
            //Foreign Key
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);

            task.Property(p => p.Title).IsRequired().HasMaxLength(100);
            task.Property(p => p.Description);
            task.Property(p => p.TaskPriority);
            task.Property(p => p.Date);
            task.Ignore(p => p.Resume);


        });
    }
}