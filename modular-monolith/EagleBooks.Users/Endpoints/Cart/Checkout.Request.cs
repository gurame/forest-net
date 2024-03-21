namespace EagleBooks.Users.Endpoints.Cart;

internal record CheckoutRequest(Guid ShippingAddressId, Guid BillingAddressId);
