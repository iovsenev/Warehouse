using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces;

namespace Warehouse.Api.Controllers;
[Route("[controller]")]
public class HealthController: ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok("It is ok");
    }

    
}