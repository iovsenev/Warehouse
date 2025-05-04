using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application.AuthService;
using Warehouse.Application.Commands.CreateCustomer;
using Warehouse.Application.Commands.CreateItem;

namespace Warehouse.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateCustomerCommand>();
        services.AddScoped<CreateItemCommand>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
