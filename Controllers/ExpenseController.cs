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
        var account = (Account)HttpContext.Items["CurrentAccount"]!;

        await expenseService.CreateAsync(dto, account);

        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateExpense(string id, [FromBody] UpdateExpenseDto dto)
    {
        var account = (Account)HttpContext.Items["CurrentAccount"]!;

        await expenseService.UpdateAsync(id, dto, account.Id!);

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpenses(string id)
    {
        Account account = (Account)HttpContext.Items["CurrentAccount"]!;

        return Ok(await expenseService.GetExpenseById(id, account.Id!));
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenses()
    {
        Account account = (Account)HttpContext.Items["CurrentAccount"]!;

        return Ok(await expenseService.GetExpenses(account.Id!));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpenseById(string id)
    {
        Account account = (Account)HttpContext.Items["CurrentAccount"]!;

        await expenseService.DeleteExpenseById(id, account.Id!);

        return Ok();
    }
}
