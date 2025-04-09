using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Models;
using PersonalExpensesApi.Services;

namespace PersonalExpensesApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class ExpenseController(ExpenseService expenseService)
    : CrudController<Expense, Expense, UpdateExpenseDto>(expenseService) { }
