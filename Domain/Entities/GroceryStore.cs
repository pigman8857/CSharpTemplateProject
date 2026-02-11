namespace JoiDelivery.Domain.Entities;

public class GroceryStore : Outlet
{
    public HashSet<GroceryProduct> Inventory { get; set; } = [];
}