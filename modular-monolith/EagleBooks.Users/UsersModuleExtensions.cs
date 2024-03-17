using System.Reflection;
using EagleBooks.Users.Data;
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
    
    mediatRAssemblies.Add((Assembly)typeof(UsersModuleExtensions).Assembly);
    
    services.AddScoped<IApplicationUserRepository, EfApplicationUserRepository>();
    
    logger.Information("{Module} module services registered", "Users");
    return services;
  }
}
