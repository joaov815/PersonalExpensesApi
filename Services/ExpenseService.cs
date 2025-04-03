using AutoMapper;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Services;

public class ExpenseService(AppDbContext context, IMapper mapper)
    : CrudService<Expense, UpdateExpenseDto>(context, mapper) { }
