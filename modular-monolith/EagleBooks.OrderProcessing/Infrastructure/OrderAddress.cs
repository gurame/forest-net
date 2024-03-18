using EagleBooks.OrderProcessing.Domain;

namespace EagleBooks.OrderProcessing.Infrastructure;

// This is the materialized view's data model
internal record OrderAddress(Guid Id, Address Address);
