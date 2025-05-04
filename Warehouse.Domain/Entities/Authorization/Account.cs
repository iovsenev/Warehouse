using Microsoft.AspNetCore.Identity;

namespace Warehouse.Domain.Entities.Authorization;
public  class Account : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SecondName { get; set; }
}
