using Catalog.API.Middleware;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.AspNetCore.Builder;

namespace Catalog.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(Program)); // or typeof(MappingProfile)
        builder.Services.AddControllers();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>(); 
        builder.Services.AddScoped<IAuthService, AuthService>();

        // Add Authentication
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidateAudience = true,
                ValidAudience = jwtSettings["Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddDbContext<CatalogContext>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 36))
            ));
        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddDbContext<CatalogContext>(options =>
             options.UseMySql(
                 builder.Configuration.GetConnectionString("DefaultConnection"),
                 new MySqlServerVersion(new Version(8, 0, 36))
    ));

        // Register the repository
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseAuthentication();
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();

        app.Run();
    }
}
