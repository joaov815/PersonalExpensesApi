using Microsoft.AspNetCore.Mvc;
using PersonalExpensesApi.Interfaces;
using PersonalExpensesApi.Services;

namespace PersonalExpensesApi.Controllers;

public class CrudController<Entity, UpdateDto>(CrudService<Entity, UpdateDto> service)
    : ControllerBase
    where Entity : class, IBaseEntity
    where UpdateDto : class
{
    [HttpPost]
    public async Task<IActionResult> AddExpense([FromBody] Entity dto)
    {
        // var account = (Account)HttpContext.Items["CurrentAccount"]!;

        await service.CreateAsync(dto);

        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateExpense(string id, [FromBody] UpdateDto dto)
    {
        // var account = (Account)HttpContext.Items["CurrentAccount"]!;

        await service.UpdateAsync(id, dto);

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        // Account account = (Account)HttpContext.Items["CurrentAccount"]!;

        return Ok(await service.GetByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        // Account account = (Account)HttpContext.Items["CurrentAccount"]!;

        return Ok(await service.ListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpenseById(string id)
    {
        // Account account = (Account)HttpContext.Items["CurrentAccount"]!;

        await service.DeleteByIdAsync(id);

        return Ok();
    }
}
