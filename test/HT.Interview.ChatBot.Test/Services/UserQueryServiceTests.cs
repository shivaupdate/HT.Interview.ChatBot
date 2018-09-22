using HT.Framework;
using HT.Interview.ChatBot.Common.DTO;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace HT.Interview.ChatBot.Test.Services
{
    public class UserQueryServiceTests
    {
        public UserQueryServiceTests()
        {
            TestFactory testFactory = new TestFactory();
            (Mock<UserService> mockService, Mock<DbSet<User>> mockDbSet) result = testFactory.CreateMockUserQueryService();
            Sut = result.mockService;
            MockDbSet = result.mockDbSet;
        }

        public Mock<UserService> Sut { get; }
        public Mock<DbSet<User>> MockDbSet { get; }

        [Fact]
        [Trait("Category", "Service_Query")]
        public async Task GetUsersAsync_ReturnsUsers_GivenUsersExist()
        {
            //Arrange
            UserDetail ud = new UserDetail();

            //Act
            Response<System.Collections.Generic.IEnumerable<UserDetail>> response = await Sut.Object.GetUsersAsync(ud);

            //Assert
            Assert.True(response.IsSuccess);
            Assert.NotEmpty(response.Value);
        } 
    }
}