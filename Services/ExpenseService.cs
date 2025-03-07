using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Services;

public class ExpenseService(AppDbContext context, IMapper mapper)
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

    public async Task UpdateAsync(string id, UpdateExpenseDto dto, string accountId)
    {
        var expense = await GetExpenseById(id, accountId);

        mapper.Map(dto, expense);

        // context.Add(updatedExpense);

        await context.SaveChangesAsync();
    }

    public async Task<List<Expense>> GetExpenses(string accountId)
    {
        var expenses = await context.Expenses.Where(e => e.AccountId == accountId).ToListAsync();

        return expenses;
    }

    public async Task<Expense> GetExpenseById(string id, string accountId)
    {
        var expense =
            await context.Expenses.FirstOrDefaultAsync(e => e.Id == id && e.AccountId == accountId)
            ?? throw new Exception();

        return expense;
    }

    public async Task DeleteExpenseById(string id, string accountId)
    {
        var expense = await GetExpenseById(id, accountId);

        context.Expenses.Remove(expense);

        await context.SaveChangesAsync();
    }
}
