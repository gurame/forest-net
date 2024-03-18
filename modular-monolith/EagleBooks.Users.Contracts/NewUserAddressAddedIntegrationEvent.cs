using EagleBooks.SharedKernel;

namespace EagleBooks.Users.Contracts;

public record NewUserAddressAddedIntegrationEvent(UserAddressDetails Details)
  : IntegrationEventBase;
