using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application.AuthService;
using Warehouse.Application.Commands.CreateCustomer;

namespace Warehouse.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateCustomerCommand>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
