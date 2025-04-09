using AutoMapper;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Services;

public class ExpenseKindService(AppDbContext context, IMapper mapper)
    : CrudService<ExpenseKind, ExpenseKind, ExpenseKind>(context, mapper)
{ }
