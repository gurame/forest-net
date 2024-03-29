using EagleBooks.OrderProcessing.Domain;
using EagleBooks.OrderProcessing.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EagleBooks.OrderProcessing.Infrastructure.Data;

internal class EfOrderRepository : IOrderRepository
{
  private readonly OrderProcessingDbContext _dbContext;

  public EfOrderRepository(OrderProcessingDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task AddAsync(Order order)
  {
    await _dbContext.Orders.AddAsync(order);
  }

  public async Task<List<Order>> ListAsync()
  {
    return await _dbContext.Orders
      .Include(o => o.OrderItems)
      .ToListAsync();
  }

  public async Task SaveChangesAsync()
  {
    await _dbContext.SaveChangesAsync();
  }
}
