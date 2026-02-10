using System;
using JoiDelivery.Domain.Entities;

namespace JoiDelivery.Domain.Interfaces;

public interface IUserRepository
{
  public Task<User> GetUserByIDAsync(string id);

}
