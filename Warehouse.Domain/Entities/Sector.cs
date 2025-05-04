using Warehouse.Domain.Entities.Base;

namespace Warehouse.Domain.Entities;
public class Sector : Entity
{
    public string Name { get; set; }
    public List<StorageCell> StorageCells { get; set; } = new();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return Name;
    }
}
