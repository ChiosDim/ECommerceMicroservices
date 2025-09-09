using BCrypt.Net;
using Catalog.Domain.Features.Auth;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims;
using System.Text;

namespace Catalog.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        // 1. Find user by email
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        // 2. Verify password (use BCrypt for secure password hashing)
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        // 3. Generate token for valid user
        var token = GenerateJwtToken(user.Email);
        return new LoginResponse { Token = token, Expiration = DateTime.UtcNow.AddHours(1) };
    }

    public async Task<User> RegisterAsync(LoginRequest request)
    {
        // Check if user already exists
        var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("User already exists");
        }

        // Create new user with hashed password
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password), // Hash the password
            CreatedAt = DateTime.UtcNow
        };

        return await _userRepository.CreateUserAsync(user);
    }

    private string GenerateJwtToken(string email)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}