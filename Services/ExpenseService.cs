using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Services;

public class ExpenseService(AppDbContext context, IMapper mapper)
    : CrudService<Expense, Expense, UpdateExpenseDto>(context, mapper, true)
{
    public override async Task CreateAsync(Expense dto, Account account)
    {
        Expense expense = _mapper.Map<Expense>(dto);

        expense.AccountId = account.Id;

        _dbSet.Add(expense);

        await Context.SaveChangesAsync();
    }

    public override async Task<List<Expense>> ListAsync(Account account)
    {
        return await QueryBuilder
            .Include(_ => _.ExpenseKind)
            .Where(_ => _.AccountId == account.Id)
            .ToListAsync();
    }
}
