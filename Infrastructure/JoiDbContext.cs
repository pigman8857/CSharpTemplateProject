using System;
using System.Reflection;
using JoiDelivery.Application.Common.Interfaces;
using JoiDelivery.Domain.Entities;
using JoiDelivery.Infrastructure.EntityTypeConfig;
using Microsoft.EntityFrameworkCore;
namespace JoiDelivery.Infrastructure;

public class JoiDbContext : DbContext, IJoiDbContext
{
  public DbSet<Cart> Carts { get; set; }
  public JoiDbContext(DbContextOptions<JoiDbContext> options) : base(options)
  {

  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    Console.WriteLine(">>>>>>>>>>>>>>> JoiDbContext.OnConfiguring()");
    options.UseSqlite("Data Source=joiDelivery.db");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    Console.WriteLine(">>>>>>>>>>>>>>> JoiDbContext.OnModelCreating()");
    base.OnModelCreating(modelBuilder);
    new CartEntityTypeConfiguration().Configure(modelBuilder.Entity<Cart>());
    // This line is key: it automatically finds your CartEntityTypeConfiguration
    // as long as it's in the same project (Assembly)
    // !!!![WARNING]!!!! The order in which the configurations will be applied is undefined, 
    // therefore this method should only be used when the order doesn't matter.
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
