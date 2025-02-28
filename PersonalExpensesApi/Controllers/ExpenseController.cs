using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Services;

namespace PersonalExpensesApi.Controllers;

[ApiController]
[Authorize]
[Route("api/expenses")]
public sealed class ExpenseController(ExpenseService expenseService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddExpense([FromBody] CreateExpenseDto dto)
    {
        await expenseService.CreateAsync(dto);

        return Ok();
    }
}
