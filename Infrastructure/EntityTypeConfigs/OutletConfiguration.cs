using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoiDelivery.Infrastructure.EntityTypeConfigs;

public class OutletConfiguration : IEntityTypeConfiguration<Outlet>
{
  public void Configure(EntityTypeBuilder<Outlet> builder)
  {
    builder.UseTpcMappingStrategy();
    builder.HasKey(c => c.Id);
    builder.Property(c => c.Name).HasColumnName("Name");
    builder.Property(c => c.Description).HasColumnName("Description"); ;
  }
}
