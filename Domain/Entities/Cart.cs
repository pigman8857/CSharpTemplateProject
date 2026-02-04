namespace JoiDelivery.Domain.Entities;

public class Cart
{
    public string Id { get; set; }
    public int? OutletId { get; set; } // Explicit FK
    public Outlet? Outlet { get; set; }
    public List<GroceryProduct> Products { get; set; } = [];
    public string? UserId { get; set; } // Explicit FK
    public User? User { get; set; }
}