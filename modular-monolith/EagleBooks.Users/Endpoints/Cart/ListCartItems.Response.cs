using EagleBooks.Users.UseCases.Cart.Models;

namespace EagleBooks.Users.Endpoints.Cart;

public class CartResponse
{
  public List<CartItemDto> CartItems { get; set; } = new();
}

