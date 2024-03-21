using System.Reflection;
using EagleBooks.Users.Domain;
using EagleBooks.Users.Infrastructure.Data;
using EagleBooks.Users.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace EagleBooks.Users;

public static class UsersModuleExtensions
{
  public static IServiceCollection AddUsersModuleServices(this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger, List<Assembly> mediatRAssemblies)
  {
    string? connectionString = config.GetConnectionString("UsersConnectionString");
    services.AddDbContext<UsersDbContext>(x =>
    {
      x.UseSqlServer(connectionString);
    });

    services.AddIdentityCore<ApplicationUser>()
      .AddEntityFrameworkStores<UsersDbContext>();

    services.AddScoped<IApplicationUserRepository, EfApplicationUserRepository>();
    services.AddScoped<IReadOnlyUserStreetAddressRepository, EfUserStreetAddressRepository>();
    
    mediatRAssemblies.Add((Assembly)typeof(UsersModuleExtensions).Assembly);
    
    logger.Information("{Module} module services registered", "Users");
    return services;
  }
}
