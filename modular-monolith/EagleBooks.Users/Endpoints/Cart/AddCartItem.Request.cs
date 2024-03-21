namespace EagleBooks.Users.Endpoints.Cart;
public record AddCartItemRequest(Guid BookId, int Quantity);
