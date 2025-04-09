using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalExpensesApi.Models;
using PersonalExpensesApi.Services;

namespace PersonalExpensesApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class ExpenseKindController(ExpenseKindService expenseService)
    : CrudController<ExpenseKind, ExpenseKind, ExpenseKind>(expenseService) { }
