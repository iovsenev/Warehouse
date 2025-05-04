using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Commands.CreateCustomer;
using Warehouse.Application.Commands.CreateItem;
using Warehouse.Infrastructure;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("customer")]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;
    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCustomer(
        [FromBody] CreateCustomerRequest request, 
        [FromServices] CreateCustomerCommand command)
    {
        var result = await command.RunCommand(request);
        return result ? Ok(result) : BadRequest();
    }

    [HttpGet("getbyphone")]
    public async Task<IActionResult> GetByPhone(string phone)
    {
        if (string.IsNullOrEmpty(phone))
            return BadRequest("телефон не должен быть пустым");

        var customer = await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.PhoneNumber == phone);

        if (customer is null)
            return BadRequest("заказчика с таким номером не существует");

        return Ok(customer);

    }

    [HttpPost("CreateItem")]
    public async Task<IActionResult> CreateItem(
        [FromBody] CreateItemRequest dto,
        [FromServices] CreateItemCommand command,
        CancellationToken token)
    {
        var result = await command.CummandRun(dto, token);

        if (result.IsFailure)
            return BadRequest();
        return Ok(result.Value);  
    }
}
