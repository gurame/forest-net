﻿using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using EagleBooks.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace EagleBooks.Users.Domain;

internal class ApplicationUser : IdentityUser, IHaveDomainEvents
{
  public string FullName { get; set; } = String.Empty;
  
  private readonly List<CartItem> _cartItems = [];
  public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

  private readonly List<UserStreetAddress> _addresses = new();
  public IReadOnlyCollection<UserStreetAddress> Addresses => _addresses.AsReadOnly();
  
  private List<DomainEventBase> _domainEvents = new();
  [NotMapped]
  public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
  void IHaveDomainEvents.ClearDomainEvents() => _domainEvents.Clear();
  internal void AddItemToCart(CartItem item)
  {
    Guard.Against.Null(item);
    var existingBook = _cartItems.SingleOrDefault(x => x.BookId == item.BookId);
    if (existingBook != null)
    {
      existingBook.UpdateQuantity(existingBook.Quantity + item.Quantity);
      existingBook.UpdateDescription(item.Description);
      existingBook.UpdatePrice(item.UnitPrice);
      return;
    }
    _cartItems.Add(item);
  }
  
  internal UserStreetAddress AddAddress(Address address)
  {
    Guard.Against.Null(address);

    // find existing address and just return it
    var existingAddress = _addresses.SingleOrDefault(a => a.StreetAddress == address);
    if (existingAddress != null)
    {
      return existingAddress;
    }

    var newAddress = new UserStreetAddress(Id, address);
    _addresses.Add(newAddress);
    
    var domainEvent = new AddressAddedEvent(newAddress);
    RegisterDomainEvent(domainEvent);

    return newAddress;
  }
  
  internal void ClearCart()
  {
    _cartItems.Clear();
  }
}

