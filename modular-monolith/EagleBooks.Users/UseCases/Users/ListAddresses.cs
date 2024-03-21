using Ardalis.Result;
using EagleBooks.Users.Interfaces;
using EagleBooks.Users.UseCases.Users.Models;
using MediatR;

namespace EagleBooks.Users.UseCases.Users;

internal class ListAddressesQueryHandler : IRequestHandler<ListAddressesQuery, Result<List<UserAddressDto>>>
{
  private readonly IApplicationUserRepository _userRepository;

  public ListAddressesQueryHandler(IApplicationUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<Result<List<UserAddressDto>>> Handle(ListAddressesQuery request,
    CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetUserWithAddressesByEmailAsync(request.EmailAddress);

    if (user is null)
    {
      return Result.Unauthorized();
    }

    return user!.Addresses!
      .Select(ua => new UserAddressDto(ua.Id, ua.StreetAddress.Street1,
        ua.StreetAddress.Street2,
        ua.StreetAddress.City,
        ua.StreetAddress.State,
        ua.StreetAddress.PostalCode,
        ua.StreetAddress.Country))
      .ToList();
  }
}
