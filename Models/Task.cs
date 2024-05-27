using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    public DateTime? DateToEnd { get; set; }

    public virtual Category Category { get; set; }

    [JsonIgnore]
    public string Resume { get; set; }
}

public enum Priority
{
    Low,
    Mid,
    High
}