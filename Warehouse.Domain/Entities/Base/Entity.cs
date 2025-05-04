namespace Warehouse.Domain.Entities.Base;
public abstract class Entity
{
    public Guid Id { get; set; }

    protected virtual IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
            return false;

        var other = (Entity)obj;

        return GetEqualityComponents().
            SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(17, (hash, component) =>
                hash * 23 + (component?.GetHashCode() ?? 0));
    }

    public static bool operator ==(Entity left, Entity right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right) =>
         !(left == right);
}
