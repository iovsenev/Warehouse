using Microsoft.AspNetCore.Identity;
using Warehouse.Domain.Entities.Authorization;

namespace Warehouse.Application.AuthService;
public interface ITokenService
{
    string GenerateJwtToken(Account user);
}