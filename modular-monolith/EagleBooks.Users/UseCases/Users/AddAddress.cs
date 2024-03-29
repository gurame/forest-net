using Ardalis.Result;
using EagleBooks.Users.Domain;
using EagleBooks.Users.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EagleBooks.Users.UseCases.Users;

internal class AddAddressToUserHandler : IRequestHandler<AddAddressToUserCommand, Result>
{
  private readonly IApplicationUserRepository _userRepository;
  private readonly ILogger<AddAddressToUserHandler> _logger;

  public AddAddressToUserHandler(IApplicationUserRepository userRepository,
    ILogger<AddAddressToUserHandler> logger)
  {
    _userRepository = userRepository;
    _logger = logger;
  }

  public async Task<Result> Handle(AddAddressToUserCommand request, CancellationToken ct)
  {
    var user = await _userRepository.GetUserWithAddressesByEmailAsync(request.EmailAddress);

    if (user is null)
    {
      return Result.Unauthorized();
    }

    var addressToAdd = new Address(request.Street1,
      request.Street2,
      request.City,
      request.State,
      request.PostalCode,
      request.Country);
    var userAddress = user.AddAddress(addressToAdd);
    await _userRepository.SaveChangesAsync();

    _logger.LogInformation("[UseCase] Added address {address} to user {email} (Total: {total})",
      userAddress.StreetAddress,
      request.EmailAddress,
      user.Addresses.Count);

    return Result.Success();
  }
}
