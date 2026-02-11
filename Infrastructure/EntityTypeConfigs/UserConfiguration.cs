using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoiDelivery.Infrastructure.EntityTypeConfigs;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasKey(u => u.Id);
    builder.Property(u => u.Username).IsRequired();
    builder.Property(u => u.FirstName).IsRequired();
    builder.Property(u => u.LastName).IsRequired();
    builder.Property(u => u.PhoneNumber).IsRequired();
    builder.Property(u => u.Email).IsRequired();
  }
}
