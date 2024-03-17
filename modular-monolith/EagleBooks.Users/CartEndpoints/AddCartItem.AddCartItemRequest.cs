namespace EagleBooks.Users.CartEndpoints;
public record AddCartItemRequest(Guid BookId, int Quantity);
