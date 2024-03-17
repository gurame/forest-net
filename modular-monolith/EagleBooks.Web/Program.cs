using System.Reflection;
using EagleBooks.Books;
using EagleBooks.Users;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Serilog;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting EagleBooks.Web Host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
{
  config.ReadFrom.Configuration(builder.Configuration);
});

builder.Services.AddFastEndpoints()
  .AddAuthenticationJwtBearer(x =>
  {
    x.SigningKey = builder.Configuration["Auth:JwtSecret"];
  })
  .AddAuthorization()
  .SwaggerDocument();

// Add module services
List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
builder.Services.AddBooksModuleServices(builder.Configuration, logger, mediatRAssemblies);
builder.Services.AddUsersModuleServices(builder.Configuration, logger, mediatRAssemblies);

// Set up mediatR
builder.Services.AddMediatR(cfg =>
  cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));

var app = builder.Build();

app.UseAuthentication()
  .UseAuthorization();

app.UseFastEndpoints()
  .UseSwaggerGen();

app.Run();
public partial class Program {}
