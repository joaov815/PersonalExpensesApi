using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalExpensesApi.Models;

public class Expense : BaseEntity
{
    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Value { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    public int? InstallmentsTotal { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? InstallmentValue { get; set; }

    public int? CurrentInstallment { get; set; }

    public Guid? ExpenseKindId { get; set; }
    public ExpenseKind? ExpenseKind { get; set; }

    public Guid? PaymentKindId { get; set; }
    public PaymentKind? PaymentKind { get; set; }

    [Required]
    public Guid AccountId { get; set; }
    public required Account Account { get; set; }
}