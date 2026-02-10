using JoiDelivery.Domain.Entities;
using JoiDelivery.Seed;
using JoiDelivery.Presentation.Interfaces;
using JoiDelivery.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using JoiDelivery.Application.Settings;

namespace JoiDelivery.Application.Services;

public class ProductService : IProductService
{
    private readonly ServerSettings _options;

    public ProductService(IOptions<ServerSettings> options)
    {
        _options = options.Value;
    }
    private readonly List<GroceryProduct> _products = SeedData.GroceryProducts;

    public GroceryProduct? GetProduct(string productId, string outletId) =>
        _products.FirstOrDefault(p =>
            p.Id == productId && p.Store?.Id == outletId);
}