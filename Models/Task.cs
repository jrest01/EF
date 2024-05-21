using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.models;

public class Task
{
    //[Key]
    public Guid TaskId { get; set; }
    // [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }

    // [Required]
    // [MaxLength(150)]
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority TaskPriority { get; set; }
    public DateTime Date { get; set; }

    public virtual Category Category { get; set; }

    public string Resume { get; set; }
}

public enum Priority
{
    Low,
    Mid,
    High
}