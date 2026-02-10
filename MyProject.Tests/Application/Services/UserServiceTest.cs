using System;
using System.Net.Mime;
using Castle.Components.DictionaryAdapter.Xml;
using JoiDelivery.Application.Common.Interfaces;
using JoiDelivery.Application.Services;
using JoiDelivery.Application.Settings;
using JoiDelivery.Domain.Entities;
using JoiDelivery.Domain.Interfaces;
using JoiDelivery.Presentation.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;

namespace MyProject.Tests.Application.Services;


public class UserServiceTest
{
  private readonly Mock<IUserRepository> _mockedUserRepo;
  private readonly IUserService _userService;
  public UserServiceTest()
  {
    _mockedUserRepo = new Mock<IUserRepository>();
    var settings = new ServerSettings
    {
      ServerName = "localhost",
      Port = 8080
    };

    // 2. Wrap it using Options.Create
    //IOptions<ServerSettings> options = Options.Create(settings);

    _userService = new UserService(_mockedUserRepo.Object);
  }



  public static IEnumerable<object[]> UserTestData => new List<object[]>
  {
      new object[] { "User01","User01", "John", "Doe" },
  };

  [Theory]
  [MemberData(nameof(UserTestData))]
  public async Task FetchUserFromDBById_Success(string findingId, string id, string firstName, string lastname)
  {
    _mockedUserRepo.Setup(context => context.GetUserByIDAsync(It.IsAny<string>()))
      .ReturnsAsync(new User { Id = id, FirstName = firstName, LastName = lastname });

    //Act
    var result = await _userService.FetchUserFromDBById(findingId);


    // Assert
    Assert.NotNull(result);

  }
}
