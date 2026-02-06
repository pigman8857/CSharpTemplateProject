using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoiDelivery.Infrastructure.EntityTypeConfigs;

public class FoodProductConfiguration : IEntityTypeConfiguration<FoodProduct>
{
  public void Configure(EntityTypeBuilder<FoodProduct> builder)
  {
    builder.ToTable("FoodProduct");
    builder.Property(c => c.Name).IsRequired();
    builder.Property(c => c.MaxRecommendedPrice);
  }
}
