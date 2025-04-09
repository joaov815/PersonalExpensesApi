using Microsoft.AspNetCore.Mvc;
using PersonalExpensesApi.Interfaces;
using PersonalExpensesApi.Models;
using PersonalExpensesApi.Services;

namespace PersonalExpensesApi.Controllers;

public class CrudController<Entity, CreateDto, UpdateDto>(
    CrudService<Entity, CreateDto, UpdateDto> service
) : ControllerBase
    where Entity : class, IBaseEntity
    where CreateDto : class
    where UpdateDto : class
{
    protected Account GetAccount()
    {
        return (Account)HttpContext.Items["CurrentAccount"]!
            ?? throw new Exception("Account not found");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDto dto)
    {
        await service.CreateAsync(dto, GetAccount());

        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateExpense(string id, [FromBody] UpdateDto dto)
    {
        await service.UpdateAsync(id, dto, GetAccount());

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await service.GetByIdAsync(id, GetAccount()));
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        return Ok(await service.ListAsync(GetAccount()));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpenseById(string id)
    {
        await service.DeleteByIdAsync(id, GetAccount());

        return Ok();
    }
}
