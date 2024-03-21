using Ardalis.Result;
using EagleBooks.Users.UseCases.Users.Models;
using MediatR;

namespace EagleBooks.Users.UseCases.Users;

internal record GetUserByIdQuery(Guid UserId) : IRequest<Result<UserDto>>;
