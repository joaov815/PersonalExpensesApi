using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Models;
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
        if (
            HttpContext.Items.TryGetValue("CurrentAccount", out var userObj)
            && userObj is Account account
        )
        {
            await expenseService.CreateAsync(dto, account);

            return Ok();
        }

        return StatusCode(500, "An unexpected error occurred.");
    }
}
