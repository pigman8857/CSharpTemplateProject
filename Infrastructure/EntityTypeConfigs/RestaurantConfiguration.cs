using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoiDelivery.Infrastructure.EntityTypeConfigs;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
  public void Configure(EntityTypeBuilder<Restaurant> builder)
  {
    builder.Property(r => r.Name).IsRequired();
    builder.Property(r => r.Description);
  }
}

