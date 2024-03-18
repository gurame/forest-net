using EagleBooks.OrderProcessing.Domain;

namespace EagleBooks.OrderProcessing.Interfaces;

internal interface IOrderRepository
{
  Task<List<Order>> ListAsync();
  Task AddAsync(Order order);
  Task SaveChangesAsync();
}
