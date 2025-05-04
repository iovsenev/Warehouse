using Microsoft.AspNetCore.Identity;
using Warehouse.Domain.Common;
using Warehouse.Domain.Entities.Authorization;

namespace Warehouse.Api;

public class AdminAdder
{
    private readonly UserManager<Account> _userManager;
    private readonly RoleManager<Function> _roleManager;
    private readonly IConfiguration _config;

    public AdminAdder(
        UserManager<Account> userManager,
        RoleManager<Function> roleManager, 
        IConfiguration config)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
    }

    public async Task AddAdmin()
    {
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            var function = new Function("Admin");
            function.Permisions = Permissions.Admin;

            await _roleManager.CreateAsync(function);
        }

        var adminName = _config["AdminCredentials:UserName"];
        var adminUser = await _userManager.FindByNameAsync(adminName);

        if (adminUser == null)
        {
            adminUser = new Account
            {
                UserName = adminName,
                Email = _config["AdminCredentials:Email"],
                EmailConfirmed = true,
                FirstName = "first",
                LastName = "last",
                SecondName = "second"
                
            };

            var result = await _userManager.CreateAsync(adminUser, _config["AdminCredentials:Password"]);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, "Admin");
                Console.WriteLine("Администратор создан успешно!");
            }
            else
            {
                Console.WriteLine($"Ошибка при создании администратора: {string.Join(", ", result.Errors)}");
            }
        }
        else
        {
            Console.WriteLine("Администратор уже существует");
        }
    }
}
