using Ardalis.Result;
using MediatR;

namespace EagleBooks.Users.Contracts;

public record UserDetailsByIdQuery(Guid UserId) :
  IRequest<Result<UserDetails>>;
