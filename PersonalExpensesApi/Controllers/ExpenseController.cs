using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalExpensesApi.Data;

namespace PersonalExpensesApi.Controllers;

[ApiController]
[Route("api/expenses")]
public sealed class ExpenseController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExpenseController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetExpenses()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok(new { UserId = userId, Expenses = new[] { "Expense1", "Expense2" } });
    }
}
