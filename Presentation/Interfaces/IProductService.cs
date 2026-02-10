using System;
using JoiDelivery.Domain.Entities;

namespace JoiDelivery.Presentation.Interfaces;

public interface IProductService
{
  public GroceryProduct? GetProduct(string productId, string outletId);
}
