using System.ComponentModel.DataAnnotations;

namespace EntityFramework.models;

public class Category
{
    //[Key]
    public Guid CategoryId { get; set; }

    // [Required]
    // [MaxLength(100)]
    public string? Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Task> Tasks { get; set; }
}