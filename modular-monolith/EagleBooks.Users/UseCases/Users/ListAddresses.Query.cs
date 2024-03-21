using Ardalis.Result;
using EagleBooks.Users.UseCases.Users.Models;
using MediatR;

namespace EagleBooks.Users.UseCases.Users;
internal record ListAddressesQuery(string EmailAddress) :
  IRequest<Result<List<UserAddressDto>>>;
