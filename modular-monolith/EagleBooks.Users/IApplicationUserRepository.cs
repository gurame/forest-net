namespace EagleBooks.Users;

internal interface IApplicationUserRepository
{
  Task<ApplicationUser> GetUserCartByEmailAsync(string emailAddress);
  Task SaveChangesAsync();
}
