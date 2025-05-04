using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Domain.Interfaces;
using Warehouse.Infrastructure.Repositories;

namespace Warehouse.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(config.GetConnectionString("Database"));
        });
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;

    }
}
