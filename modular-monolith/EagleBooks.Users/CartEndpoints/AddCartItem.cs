using System.Security.Claims;
using Ardalis.Result;
using EagleBooks.Users.UseCases;
using FastEndpoints;
using MediatR;

namespace EagleBooks.Users.CartEndpoints;

internal class AddCartItem : Endpoint<AddCartItemRequest>
{
  private readonly IMediator _mediator;
  public AddCartItem(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Post("/cart");
    Claims("EmailAddress");
  }

  public override async Task HandleAsync(AddCartItemRequest req, CancellationToken ct)
  {
    var emailAddress = User.FindFirstValue("EmailAddress");
    var command = new AddItemToCartCommand(req.BookId, req.Quantity, emailAddress!);
    var result = await _mediator.Send(command, ct);
    if (result.Status == ResultStatus.Unauthorized)
    {
      await SendUnauthorizedAsync();
    }
    else
    {
      await SendOkAsync();
    }
  }
}

