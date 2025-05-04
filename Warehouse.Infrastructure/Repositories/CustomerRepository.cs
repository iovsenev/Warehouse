using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces;

namespace Warehouse.Infrastructure.Repositories;
public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateCustomer(Customer customer)
    {
        if (customer is null)
            throw new ArgumentNullException(nameof(customer));

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }
}
