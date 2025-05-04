using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Common;
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

    public async Task<Result<Customer>> GetById(Guid customerId, CancellationToken token)
    {
        var customer = await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync( c => c.Id == customerId);

        if (customer is null)
            return Error.NotFound($"customer with id : {customerId} is not found");

        return customer;
    }

    public async Task<Result<Guid>> CreateItem(Guid customerId, Item item, CancellationToken token)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId, token);

        if (customer is null)
        {
            return Error.NotFound($"customer with id : {customerId} is not found");
        }
        try
        {
            customer.Items.Add(item);
            await _context.SaveChangesAsync();

            return item.Id;
        }
        catch (Exception ex)
        {
            return Error.InternalServer($"some thing wrong to db message: {ex.Message}");
        }
    }
}
