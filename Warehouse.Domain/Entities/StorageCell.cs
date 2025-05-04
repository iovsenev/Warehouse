using Warehouse.Domain.Entities.Base;

namespace Warehouse.Domain.Entities;
public class StorageCell : Entity
{
    public string Name { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public bool IsLocked { get; set; }

    public Sector Sector { get; set; }
    public Item? StoredItem { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return Name;
        yield return Sector;
    }
}
