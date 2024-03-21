using Ardalis.Result;
using MediatR;

namespace EagleBooks.Users.UseCases.Cart;

internal record AddItemToCartCommand(Guid BookId, int Quantity, string EmailAddress) : IRequest<Result>;
