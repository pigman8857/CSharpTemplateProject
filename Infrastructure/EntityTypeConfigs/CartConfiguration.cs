using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoiDelivery.Infrastructure.EntityTypeConfigs;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
       public void Configure(EntityTypeBuilder<Cart> builder)
       {
              // 1. Primary Key
              builder.HasKey(c => c.Id);

              // 2. Foreign Key to Outlet (Many-to-One)
              // Assumes one Outlet can have multiple Carts
              builder.HasOne(c => c.Outlet)
                     .WithMany()
                     .HasForeignKey("OutletId"); // Shadow property if not in class

              // 3. Many Relationship (One-to-Many)
              // 1 Cart has many GroceryProducts
              builder.HasMany(c => c.Products)
                     .WithOne()
                     .HasForeignKey("CartId"); // Assumes GroceryProduct has a CartId

              // 4. One-to-One with User
              builder.HasOne(c => c.User)
                     .WithOne(u => u.Cart)
                     // This line is the fix! It tells EF that 'Cart' is the one 
                     // that carries the 'UserId' shadow column.
                     .HasForeignKey<Cart>("UserId")
                     .IsRequired(false)
                     .OnDelete(DeleteBehavior.Cascade);
       }
}
