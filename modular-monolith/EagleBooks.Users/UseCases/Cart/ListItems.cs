using Ardalis.Result;
using EagleBooks.Users.Interfaces;
using EagleBooks.Users.UseCases.Cart.Models;
using MediatR;

namespace EagleBooks.Users.UseCases.Cart;

internal class ListCartItemsQueryHandler : IRequestHandler<ListCartItemsQuery, Result<List<CartItemDto>>>
{
  private readonly IApplicationUserRepository _userRepository;

  public ListCartItemsQueryHandler(IApplicationUserRepository userRepository)
  {
    _userRepository = userRepository;
  }
  public async Task<Result<List<CartItemDto>>> Handle(ListCartItemsQuery request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetUserWithCartByEmailAsync(request.EmailAddress!);
    if (user is null)
    {
      return Result.Unauthorized(); 
    }

    return user.CartItems.Select(item =>
        new CartItemDto(item.Id, item.BookId, item.Description, item.Quantity, item.UnitPrice))
      .ToList();
  }
}
