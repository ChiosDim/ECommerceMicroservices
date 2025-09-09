using Catalog.Domain.Features.Auth;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<User> CreateUserAsync(User user);
}