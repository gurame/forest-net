using EagleBooks.Users.Domain;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;

namespace EagleBooks.Users.Endpoints.Users;

internal class Login : Endpoint<CreateUserRequest>
{
  private readonly UserManager<ApplicationUser> _userManager;

  public Login(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }

  public override void Configure()
  {
    Post("/users/login");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
  {
    var user = await _userManager.FindByEmailAsync(req.Email!);
    if (user is null)
    {
      await SendUnauthorizedAsync();
      return;
    }
    var loginSuccessful = await _userManager.CheckPasswordAsync(user ,req.Password);
    if (!loginSuccessful)
    {
      await SendUnauthorizedAsync();
      return;
    }

    var jwtSecret = Config["Auth:JwtSecret"];
    var token = JwtBearer.CreateToken(
      x =>
      {
        x.SigningKey = jwtSecret!;
        x.User.Claims.Add(("EmailAddress", user.Email)!);
      });
    
    await SendAsync(token);
  }
}

