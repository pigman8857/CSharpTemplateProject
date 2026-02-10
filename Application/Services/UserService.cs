using JoiDelivery.Domain.Entities;
using JoiDelivery.Seed;
using JoiDelivery.Presentation.Interfaces;
using JoiDelivery.Domain.Interfaces;
namespace JoiDelivery.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    private readonly List<User> _users = SeedData.Users;

    public User? FetchUserById(string userId) => _users.FirstOrDefault(user => user.Id == userId);

    public async Task<User> FetchUserFromDBById(string userId)
    {
        return await _userRepository.GetUserByIDAsync(userId);
    }

}
