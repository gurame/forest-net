using System.Security.Claims;
using Ardalis.Result;
using EagleBooks.Users.UseCases.Users;
using FastEndpoints;
using MediatR;

namespace EagleBooks.Users.Endpoints.Users;

internal sealed class AddAddress : Endpoint<AddAddressRequest>
{
  private readonly IMediator _mediator;

  public AddAddress(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post("/users/addresses");
    Claims("EmailAddress");
  }

  public override async Task HandleAsync(AddAddressRequest request,
    CancellationToken cancellationToken = default)
  {
    var emailAddress = User.FindFirstValue("EmailAddress");

    var command = new AddAddressToUserCommand(emailAddress!,
      request.Street1,
      request.Street2,
      request.City,
      request.State,
      request.PostalCode,
      request.Country);

    var result = await _mediator.Send(command);

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
