using System;
using JoiDelivery.Application.Dtos;
using JoiDelivery.Domain.Entities;

namespace JoiDelivery.Presentation.Interfaces;

public interface ICartService
{
  public CartProductInfo AddProductToCartForUser(AddProductRequest addProductRequest);
  public Cart? GetCartForUser(string userId);
  public void GetSettings();
}
