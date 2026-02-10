using System;
using JoiDelivery.Domain.Entities;

namespace JoiDelivery.Presentation.Interfaces;

public interface IUserService
{
  public User? FetchUserById(string userId);

  public Task<User> FetchUserFromDBById(string userId);
}
