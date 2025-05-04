using Warehouse.Domain.Common;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Interfaces;
public interface ICustomerRepository
{
    Task CreateCustomer(Customer customer);
    Task<Result<Guid>> CreateItem(Guid customerId, Item item, CancellationToken token);
    Task<Result<Customer>> GetById(Guid customerId, CancellationToken token);
}