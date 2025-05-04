using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Interfaces;
public interface ICustomerRepository
{
    Task CreateCustomer(Customer customer);
}