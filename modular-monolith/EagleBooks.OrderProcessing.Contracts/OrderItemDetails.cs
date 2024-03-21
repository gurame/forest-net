namespace EagleBooks.OrderProcessing.Contracts;
public record OrderItemDetails(Guid BookId,
  int Quantity,
  decimal UnitPrice,
  string Description);
