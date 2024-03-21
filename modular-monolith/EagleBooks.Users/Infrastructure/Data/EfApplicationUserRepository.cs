﻿using EagleBooks.Users.Domain;
using EagleBooks.Users.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EagleBooks.Users.Infrastructure.Data;

internal class EfApplicationUserRepository : IApplicationUserRepository
{
  private readonly UsersDbContext _dbContext;
  public EfApplicationUserRepository(UsersDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public Task<ApplicationUser> GetUserByIdAsync(Guid userId)
  {
    return _dbContext.ApplicationUsers
      .SingleAsync(user => user.Id == userId.ToString());
  }
  public Task<ApplicationUser> GetUserWithAddressesByEmailAsync(string email)
  {
    return _dbContext.ApplicationUsers
      .Include(user => user.Addresses)
      .SingleAsync(user => user.Email == email);

  }
  public Task<ApplicationUser> GetUserWithCartByEmailAsync(string email)
  {
    return _dbContext.ApplicationUsers
      .Include(user => user.CartItems)
      .SingleAsync(user => user.Email == email);
  }
  public async Task SaveChangesAsync()
  {
    await _dbContext.SaveChangesAsync();
  }
}
