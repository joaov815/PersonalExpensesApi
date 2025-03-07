namespace PersonalExpensesApi.Dtos;

public class UpdateExpenseDto
{
    public required string? Name { get; set; }
    public decimal? Value { get; set; }
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
    public int? InstallmentsTotal { get; set; }
    public decimal? InstallmentValue { get; set; }
    public int? CurrentInstallment { get; set; }
    public string? ExpenseKindId { get; set; }
    public string? PaymentKindId { get; set; }
}
