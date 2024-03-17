using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace EagleBooks.Users;

internal class ApplicationUser : IdentityUser
{
  public string FullName { get; set; } = String.Empty;
  private readonly List<CartItem> _cartItems = [];
  public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

  public void AddItemToCart(CartItem item)
  {
    Guard.Against.Null(item);
    var existingBook = _cartItems.SingleOrDefault(x => x.BookId == item.BookId);
    if (existingBook != null)
    {
      existingBook.UpdateQuantity(existingBook.Quantity + item.Quantity);
      existingBook.UpdateDescription(item.Description);
      existingBook.UpdatePrice(item.UnitPrice);
      return;
    }
    _cartItems.Add(item);
  }
}

