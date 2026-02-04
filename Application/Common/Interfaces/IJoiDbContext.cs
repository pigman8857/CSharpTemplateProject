using System;
using JoiDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JoiDelivery.Application.Common.Interfaces;

public interface IJoiDbContext
{
  DbSet<Cart> Carts { get; }
  // Add other DbSets here as you create them
  // DbSet<Outlet> Outlets { get; }

  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
