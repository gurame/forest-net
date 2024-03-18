using EagleBooks.SharedKernel;

namespace EagleBooks.OrderProcessing.Domain;

internal class OrderCreatedEvent : DomainEventBase
{
  public OrderCreatedEvent(Order order)
  {
    Order = order;
  }
  public Order Order { get; }
}

