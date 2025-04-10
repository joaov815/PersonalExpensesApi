namespace PersonalExpensesApi.Models;

public class PaymentKind : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
