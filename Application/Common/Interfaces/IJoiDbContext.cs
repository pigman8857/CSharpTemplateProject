using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JoiDelivery.Application.Common.Interfaces;

public interface IJoiDbContext
{
  DbSet<Cart> Carts { get; }
  // Add other DbSets here as you create them
  // DbSet<Outlet> Outlets { get; }
  DbSet<Outlet> Outlets { get; set; }
  DbSet<FoodProduct> FoodProducts { get; set; }
  DbSet<GroceryProduct> GroceryProducts { get; set; }
  DbSet<GroceryStore> GroceryStores { get; set; }
  DbSet<Product> Products { get; set; }
  DbSet<Restaurant> Restaurants { get; set; }
  DbSet<User> Users { get; set; }

  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
