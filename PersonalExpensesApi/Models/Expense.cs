namespace PersonalExpensesApi.Models;

public class Expense : BaseEntity
{
    public required string Name { get; set; }
    public required decimal Value { get; set; }
    public required DateTime Date { get; set; }
    public string? Description { get; set; }
    public int? InstallmentsTotal { get; set; }
    public decimal? InstallmentValue { get; set; }
    public int? CurrentInstallment { get; set; }
    public ExpenseKind? ExpenseKind { get; set; }
    public PaymentKind? PaymentKind { get; set; }
    public required Account Account { get; set; }
}
