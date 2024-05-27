using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EntityFramework.models;

public class Category
{
    //[Key]
    public Guid CategoryId { get; set; }

    // [Required]
    // [MaxLength(100)]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Effort { get; set; }

    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; }
}