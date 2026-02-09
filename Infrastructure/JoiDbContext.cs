using System;
using System.Reflection;
using JoiDelivery.Application.Common.Interfaces;
using JoiDelivery.Domain.Entities;
using JoiDelivery.Infrastructure.EntityTypeConfigs;
using Microsoft.EntityFrameworkCore;
namespace JoiDelivery.Infrastructure;

public class JoiDbContext : DbContext, IJoiDbContext
{
  public DbSet<Cart> Carts { get; set; }
  public DbSet<Outlet> Outlets { get; set; }
  public DbSet<FoodProduct> FoodProducts { get; set; }
  public DbSet<GroceryProduct> GroceryProducts { get; set; }
  public DbSet<GroceryStore> GroceryStores { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Restaurant> Restaurants { get; set; }
  public DbSet<User> Users { get; set; }
  public JoiDbContext(DbContextOptions<JoiDbContext> options) : base(options)
  {

  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    // Console.WriteLine(">>>>>>>>>>>>>>> JoiDbContext.OnConfiguring()");
    // options.UseSqlite("Data Source=joiDelivery.db");

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    Console.WriteLine(">>>>>>>>>>>>>>> JoiDbContext.OnModelCreating()");
    base.OnModelCreating(modelBuilder);
    new CartConfiguration().Configure(modelBuilder.Entity<Cart>());
    new OutletConfiguration().Configure(modelBuilder.Entity<Outlet>());
    new FoodProductConfiguration().Configure(modelBuilder.Entity<FoodProduct>());
    new GroceryProductConfiguration().Configure(modelBuilder.Entity<GroceryProduct>());
    new GroceryStoreConfiguration().Configure(modelBuilder.Entity<GroceryStore>());
    new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
    new RestaurantConfiguration().Configure(modelBuilder.Entity<Restaurant>());
    new UserConfiguration().Configure(modelBuilder.Entity<User>());

    // This line is key: it automatically finds your CartEntityTypeConfiguration
    // as long as it's in the same project (Assembly)
    // !!!![WARNING]!!!! The order in which the configurations will be applied is undefined, 
    // therefore this method should only be used when the order doesn't matter.
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
