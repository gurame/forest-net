using Ardalis.Result;
using MediatR;

namespace EagleBooks.Users.UseCases.Cart;

public record CheckoutCartCommand(string EmailAddress,
  Guid shippingAddressId,
  Guid billingAddressId)
  : IRequest<Result<Guid>>;
