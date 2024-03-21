using Ardalis.Result;
using MediatR;

namespace EagleBooks.Users.UseCases.Users;

public record AddAddressToUserCommand(string EmailAddress,
  string Street1,
  string Street2,
  string City,
  string State,
  string PostalCode,
  string Country) : IRequest<Result>;
