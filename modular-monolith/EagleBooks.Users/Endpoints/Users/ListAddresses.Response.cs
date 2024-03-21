using EagleBooks.Users.UseCases.Users.Models;
namespace EagleBooks.Users.Endpoints.Users;
public class AddressListResponse
{
  public List<UserAddressDto> Addresses { get; set; } = new();
}
