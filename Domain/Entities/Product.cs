namespace JoiDelivery.Domain.Entities;

public abstract class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public float MaxRecommendedPrice { get; set; }
}