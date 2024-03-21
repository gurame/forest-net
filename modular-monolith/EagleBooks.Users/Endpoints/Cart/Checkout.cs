using System.Security.Claims;
using Ardalis.Result;
using EagleBooks.Users.UseCases.Cart;
using FastEndpoints;
using MediatR;

namespace EagleBooks.Users.Endpoints.Cart;

internal class Checkout : Endpoint<CheckoutRequest, CheckoutResponse>
{
  private readonly IMediator _mediator;
  
  public Checkout(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post("/cart/checkout");
    Claims("EmailAddress");
  }

  public override async Task HandleAsync(CheckoutRequest request, CancellationToken ct = default)
  {
    var emailAddress = User.FindFirstValue("EmailAddress");

    var command = new CheckoutCartCommand(emailAddress!,
      request.ShippingAddressId,
      request.BillingAddressId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.Unauthorized)
    {
      await SendUnauthorizedAsync();
    }
    else
    {
      await SendOkAsync(new CheckoutResponse(result.Value));
    }
  }

}

