using Microsoft.Extensions.Configuration;

namespace CaronaUFF.Infrastructure;

public class ConnectionStrings
{
    public static string GetDefaultConnection()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.Development.json")
            .Build();

        return configuration.GetConnectionString("DefaultConnection");
    }
}