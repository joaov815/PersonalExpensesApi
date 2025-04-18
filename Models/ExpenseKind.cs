namespace PersonalExpensesApi.Models;

public class ExpenseKind : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
