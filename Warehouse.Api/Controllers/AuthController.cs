using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.AuthService;
using Warehouse.Domain.Entities.Authorization;

namespace Warehouse.Api.Controllers;
[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly RoleManager<Function> _roleManager;
    private readonly UserManager<Account> _userManager;
    private readonly IConfiguration _config;
    private readonly ITokenService _tokenService;

    public AuthController(
        UserManager<Account> userManager,
        IConfiguration config,
        ITokenService tokenService,
        RoleManager<Function> roleManager)
    {
        _userManager = userManager;
        _config = config;
        _tokenService = tokenService;
        _roleManager = roleManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user == null)
            return Unauthorized("invalid user name ");

        if (!await _userManager.CheckPasswordAsync(user, model.Password))
            return Unauthorized("invalid user password ");
        var roles = await _userManager.GetRolesAsync(user);
        var permissions = new List<string>();

        foreach (var role in roles)
        {
            var function = await _roleManager.FindByNameAsync(role);
            permissions = permissions.Union(function.Permisions).ToList();
        }


        var jwtToken = _tokenService.GenerateJwtToken(user);


        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Unspecified,
            Expires = DateTime.UtcNow.AddDays(7)
        };

        Response.Cookies.Append("AuthToken", jwtToken, cookieOptions);
        return Ok(new
        {
            message = "Login success"
        });
    }
}

public record LoginDto( 
    string UserName,
    string Password);

