using Warehouse.Domain.Entities.Base;

namespace Warehouse.Domain.Entities;
public class Item : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public bool InStorage { get; set; } = false;
    public bool InProcessing { get; set; } = true;

    public StorageCell? Cell { get; set; }
    public Customer Customer { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return Customer;
    }

}
