using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoiDelivery.Infrastructure.EntityTypeConfigs;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> entityType)
  {
    entityType.UseTpcMappingStrategy();
    entityType.HasKey(p => p.Id);
    entityType.Property(p => p.Name).HasColumnName("Name").IsRequired();
    entityType.Property(p => p.MaxRecommendedPrice).HasColumnName("MaxRecommendedPrice");

  }
}
