using EagleBooks.Users.Domain;

namespace EagleBooks.Users.Interfaces;

public interface IReadOnlyUserStreetAddressRepository
{
  Task<UserStreetAddress?> GetById(Guid userStreetAddressId);
}
