using PersonalExpensesApi.Data;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Services;

public class ExpenseService(AppDbContext context)
{
    public async Task CreateAsync(CreateExpenseDto dto, Account account)
    {
        var expense = new Expense
        {
            Name = dto.Name,
            Value = dto.Value,
            AccountId = account.Id,
        };

        context.Add(expense);

        await context.SaveChangesAsync();
    }
}
