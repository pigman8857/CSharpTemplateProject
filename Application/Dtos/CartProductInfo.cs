using JoiDelivery.Domain.Entities;

namespace JoiDelivery.Application.Dtos;

public class CartProductInfo(Cart cart, Product product, float sellingPrice)
{
    public Cart Cart { get; } = cart;
    public Product Product { get; } = product;
    public float SellingPrice { get; } = sellingPrice;
}