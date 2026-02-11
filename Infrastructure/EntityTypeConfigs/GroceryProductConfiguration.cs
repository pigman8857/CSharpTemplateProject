using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoiDelivery.Infrastructure.EntityTypeConfigs;

public class GroceryProductConfiguration : IEntityTypeConfiguration<GroceryProduct>
{
  public void Configure(EntityTypeBuilder<GroceryProduct> builder)
  {
    builder.ToTable("GroceryProduct");

    builder.Property(c => c.Name).IsRequired();
    builder.Property(c => c.MaxRecommendedPrice);

    builder.Property(c => c.SellingPrice);
    builder.Property(c => c.Weight);
    builder.Property(c => c.ExpiryDate);
    builder.Property(c => c.Threshold);
    builder.Property(c => c.AvailableStock);
    builder.Property(c => c.Discount);

    //One-to-Many
    builder.HasOne(p => p.Store)           // Product has one Store
            .WithMany(s => s.Inventory);        // Store has many Products (Inventory)
    // The Foreign Key is StoreId

  }
}
