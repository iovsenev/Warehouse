using Microsoft.AspNetCore.Identity;

namespace Warehouse.Domain.Entities.Authorization;
public class Function : IdentityRole<Guid>
{
    public Function() : base(){ }

    public Function(string roleName) : base(roleName) { }

    public List<string> Permisions { get; set; } = new();
}
