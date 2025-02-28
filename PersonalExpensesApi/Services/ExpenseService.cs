using PersonalExpensesApi.Data;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Services;

public class ExpenseService(AppDbContext context)
{
    public async Task CreateAsync(CreateExpenseDto dto)
    {
        var expense = new Expense
        {
            Name = dto.Name,
            Value = dto.Value,
            AccountId = dto.AccountId,
        };

        context.Add(expense);

        await context.SaveChangesAsync();
    }
}
