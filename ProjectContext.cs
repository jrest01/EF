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
        List<Category> categoriesInit =
        [
            new Category
            {
            CategoryId = Guid.Parse("33c4d656-65f3-420b-b25f-0657f73e6e54"),
            Name = "Academy Activities",
            Effort = 10
            },
            new Category
            {
            CategoryId = Guid.Parse("df89da86-0ce8-4865-85ed-cdd55b127c54"),
            Name = "Job Activities",
            Effort = 7
            }
        ];

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.Name).IsRequired().HasMaxLength(100);
            category.Property(p => p.Description);
            category.Property(p => p.Effort);
            category.HasData(categoriesInit);
        });


        List<models.Task> tasksInit =
        [
            new models.Task
            {
                TaskId = Guid.Parse("ba8cbb16-7c89-4cd5-9495-c46febda8215"),
                CategoryId = Guid.Parse("33c4d656-65f3-420b-b25f-0657f73e6e54"),
                TaskPriority = Priority.High,
                Title = "Study English",
                Description = "Study English with Platzi until to be bilingual",
                Date = DateTime.UtcNow
            },
            new models.Task
            {
                TaskId = Guid.Parse("56ba4700-16a4-44d8-a610-feb9fec0f0b7"),
                CategoryId = Guid.Parse("df89da86-0ce8-4865-85ed-cdd55b127c54"),
                TaskPriority = Priority.Mid,
                Title = "Update COOSALUD",
                Description = "Update all COOSALUD apps",
                Date = DateTime.UtcNow
            },
        ];
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
            task.Property(p => p.DateToEnd).IsRequired(false);
            task.Ignore(p => p.Resume);

            task.HasData(tasksInit);


        });
    }
}