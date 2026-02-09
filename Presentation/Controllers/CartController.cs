using JoiDelivery.Application.Dtos;
using JoiDelivery.Domain.Entities;
using JoiDelivery.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace JoiDelivery.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController(CartService cartService) : ControllerBase
{
    [HttpPost("product")]
    public ActionResult<CartProductInfo> AddProductToCart([FromBody] AddProductRequest addProductRequest)
    {
        var result = cartService.AddProductToCartForUser(addProductRequest);

        return Ok(result);
    }

    [HttpGet("view")]
    public ActionResult<string> ViewCart([FromQuery(Name = "userId")] string userId)
    {
        cartService.GetSettings();

        var cart = cartService.GetCartForUser(userId);

        return Ok(cart);
    }
}
