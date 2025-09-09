using Catalog.Domain.Entities;
using Catalog.Domain.Features.Auth;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CatalogContext _context;

    public UserRepository(CatalogContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
}