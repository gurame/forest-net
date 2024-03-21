namespace EagleBooks.Users.UseCases.Cart.Models;
public record CartItemDto(Guid Id, Guid BookId, string Description, int Quantity, decimal UnitPrice);
