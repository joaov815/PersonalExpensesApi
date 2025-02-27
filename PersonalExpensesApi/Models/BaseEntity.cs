namespace PersonalExpensesApi.Models;

public class BaseEntity
{
    public required string Id { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}
