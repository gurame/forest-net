using Microsoft.EntityFrameworkCore;

namespace EagleBooks.Users.Data;

internal class EfApplicationUserRepository : IApplicationUserRepository
{
  private readonly UsersDbContext _dbContext;
  public EfApplicationUserRepository(UsersDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  
  public Task<ApplicationUser> GetUserCartByEmailAsync(string emailAddress)
  {
    return _dbContext.ApplicationUsers.Include(user => user.CartItems)
      .SingleAsync(x => x.Email == emailAddress);
  }

  public async Task SaveChangesAsync()
  {
    await _dbContext.SaveChangesAsync();
  }
}
