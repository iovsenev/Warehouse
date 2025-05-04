using Warehouse.Domain.Entities.Base;

namespace Warehouse.Domain.Entities;
public class Customer : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber   { get; set; }
    public string Address { get; set; }

    public List<Item> Items { get; set; } = [];

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return FirstName;
        yield return LastName;
        yield return SecondName;
    }
}
