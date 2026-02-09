using JoiDelivery.Application.Dtos;
using JoiDelivery.Application.Settings;
using JoiDelivery.Domain.Entities;
using JoiDelivery.Presentation.Interfaces;
using JoiDelivery.Seed;
using Microsoft.Extensions.Options;
namespace JoiDelivery.Application.Services;

public class CartService : ICartService
{
    private readonly ServerSettings _options;
    private readonly ProductService _productService;

    private readonly UserService _userService;
    public CartService(ProductService productService, UserService userService, IOptions<ServerSettings> options)
    {
        _options = options.Value;
        _productService = productService;
        _userService = userService;
    }

    private readonly Dictionary<string, Cart> _userCarts = SeedData.CartForUsers;

    public void GetSettings()
    {
        Console.Write($"### Port > {_options.Port}");
        Console.Write($"### ServerName > {_options.ServerName}");
    }
    public CartProductInfo AddProductToCartForUser(AddProductRequest addProductRequest)
    {

        var user = _userService.FetchUserById(addProductRequest.UserId);
        var cart = FetchCartForUser(user);
        var product = _productService.GetProduct(addProductRequest.ProductId, addProductRequest.OutletId);

        cart.Products ??= [];

        cart.Products.Add(product);

        return new CartProductInfo(cart, product, product.SellingPrice);
    }

    public Cart? GetCartForUser(string userId) =>
        _userCarts.GetValueOrDefault(userId);

    private Cart? FetchCartForUser(User user) =>
        _userCarts.GetValueOrDefault(user.Id);
}