using Ardalis.Result;
using EagleBooks.Users.UseCases.Cart.Models;
using MediatR;

namespace EagleBooks.Users.UseCases.Cart;

internal record ListCartItemsQuery(string? EmailAddress) : IRequest<Result<List<CartItemDto>>>;
