using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces;

namespace Warehouse.Application.Commands.CreateCustomer;
public class CreateCustomerCommand
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommand(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> RunCommand(CreateCustomerRequest request)
    {
        if (request == null)
            return false;
        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            SecondName = request.SecondName,
            Email = request.Email,
            PhoneNumber = request.Phone,
            Address = request.Address,
        };
        try
        {
            await _repository.CreateCustomer(customer);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"=======wrong===== {ex.Message}");
            return false;
        }

    }
}
