namespace Warehouse.Application.Commands.CreateCustomer;

public record CreateCustomerRequest(
    string FirstName,
    string LastName,
    string SecondName,
    string Email,
    string Phone,
    string Address);