using Ardalis.Result;
using EagleBooks.OrderProcessing.Infrastructure;

namespace EagleBooks.OrderProcessing.Interfaces;

internal interface IOrderAddressCache
{
  Task<Result<OrderAddress>> GetByIdAsync(Guid addressId);
  Task<Result> StoreAsync(OrderAddress orderAddress);
}
