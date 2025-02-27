using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PersonalExpensesApi.Interfaces;

namespace PersonalExpensesApi.Models;

public abstract class BaseEntity : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string Id { get; set; }

    [Required]
    [Column(TypeName = "timestamp")]
    public required DateTime CreatedAt { get; set; }

    [Required]
    [Column(TypeName = "timestamp")]
    public required DateTime UpdatedAt { get; set; }
}
