using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace Catalog.Infrastructure.Factories;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CatalogContext>
{
    public CatalogContext CreateDbContext(string[] args)
    {
        // Try multiple possible paths to find the appsettings.json
        var basePath = GetAppSettingsPath();

        Console.WriteLine($"Looking for appsettings.json in: {basePath}"); // Helpful for debugging

        // Build configuration
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Get the connection string
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException(
                "Could not find connection string 'DefaultConnection'. " +
                $"Searched in: {basePath}\\appsettings.json");
        }

        // Configure DbContext options
        var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new CatalogContext(optionsBuilder.Options);
    }

    private string GetAppSettingsPath()
    {
        // Method 1: Look in the current directory (works when running from Catalog.API)
        var currentDirectory = Directory.GetCurrentDirectory();
        if (File.Exists(Path.Combine(currentDirectory, "appsettings.json")))
        {
            return currentDirectory;
        }

        // Method 2: Look one level up in Catalog.API (works when running from solution root)
        var apiPath = Path.Combine(currentDirectory, "src", "Services", "Catalog", "Catalog.API");
        if (File.Exists(Path.Combine(apiPath, "appsettings.json")))
        {
            return apiPath;
        }

        // Method 3: Look relative to the Infrastructure project
        var infrastructurePath = Directory.GetCurrentDirectory();
        var apiPathFromInfra = Path.Combine(infrastructurePath, "..", "Catalog.API");
        if (File.Exists(Path.Combine(apiPathFromInfra, "appsettings.json")))
        {
            return Path.GetFullPath(apiPathFromInfra);
        }

        throw new FileNotFoundException("Could not find appsettings.json in any expected location");
    }
}