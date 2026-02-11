using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoiDelivery.Infrastructure.EntityTypeConfigs;

public class GroceryStoreConfiguration : IEntityTypeConfiguration<GroceryStore>
{
  public void Configure(EntityTypeBuilder<GroceryStore> builder)
  {

    builder.Property(c => c.Name);
    builder.Property(c => c.Description);

    builder.HasMany(gs => gs.Inventory)
          .WithOne(i => i.Store);
  }
}
