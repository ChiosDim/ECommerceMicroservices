using Catalog.Domain.Features.Auth;

namespace Catalog.Domain.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<User> RegisterAsync(LoginRequest request);
}