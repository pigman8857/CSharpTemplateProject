using JoiDelivery.Domain.Entities;
using JoiDelivery.Seed;

namespace JoiDelivery.Application.Services;

public class UserService
{
    private readonly List<User> _users = SeedData.Users;

    public User? FetchUserById(string userId) => _users.FirstOrDefault(user => user.Id == userId);
}
