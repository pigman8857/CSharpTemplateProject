using JoiDelivery.Domain.Entities;
using JoiDelivery.Seed;

namespace JoiDelivery.Application.Services;

public class ProductService
{
    private readonly List<GroceryProduct> _products = SeedData.GroceryProducts;

    public GroceryProduct? GetProduct(string productId, string outletId) =>
        _products.FirstOrDefault(p =>
            p.Id == productId && p.Store?.Id == outletId);
}