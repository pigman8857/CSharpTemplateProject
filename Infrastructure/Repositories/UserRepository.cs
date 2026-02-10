using System;
using JoiDelivery.Application.Common.Interfaces;
using JoiDelivery.Application.Settings;
using JoiDelivery.Domain.Entities;
using JoiDelivery.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace JoiDelivery.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  private readonly JoiDbContext _joiDbContext;
  private readonly ServerSettings _options;
  public UserRepository(JoiDbContext joiDbContext, IOptions<ServerSettings> options)
  {
    _joiDbContext = joiDbContext;
    _options = options.Value;
  }
  public async Task<User> GetUserByIDAsync(string userId)
  {
    return await _joiDbContext.Users
      .AsNoTracking()
      .Where(user => user.Id == userId)
      .Select(user => new User { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email })
      .FirstAsync();
  }
}
