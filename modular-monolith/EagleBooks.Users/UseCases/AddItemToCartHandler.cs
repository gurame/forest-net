using Ardalis.Result;
using EagleBooks.Books.Contracts;
using MediatR;

namespace EagleBooks.Users.UseCases;

internal record AddItemToCartCommand(Guid BookId, int Quantity, string EmailAddress) : IRequest<Result>;

internal class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, Result>
{
  private readonly IApplicationUserRepository _repository;
  private readonly IMediator _mediator;

  public AddItemToCartHandler(IApplicationUserRepository repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }
  
  public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
  {
    var user = await _repository.GetUserCartByEmailAsync(request.EmailAddress);
    if (user is null)
    {
      return Result.Unauthorized();
    }

    var query = new BookDetailsQuery(request.BookId);
    var result = await _mediator.Send(query);
    
    if (result.Status == ResultStatus.NotFound) return Result.NotFound();
    
    var newCartItem = new CartItem(request.BookId, $"{result.Value.Title} by {result.Value.Author}", request.Quantity, result.Value.Price);
    user.AddItemToCart(newCartItem);
    
    await _repository.SaveChangesAsync();

    return Result.Success();
  }
}

