using Ardalis.Result;
using MediatR;

namespace EagleBooks.Users.Contracts;

public record UserAddressDetailsByIdQuery(Guid AddressId) : 
  IRequest<Result<UserAddressDetails>>;
