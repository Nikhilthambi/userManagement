using Moq;
using RsnDigitalApi.Entity;
using RsnDigitalApi.Repository;
using RsnDigitalApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UserDetectionTest.ServiceTest
{
    public class UserServiceTest
    {
        private readonly UserService userService;
        private readonly Mock<IUserRepository> _mock = new Mock<IUserRepository>();

        public UserServiceTest()
        {
            userService = new UserService(_mock.Object);
        }

        [Fact]
        public async Task GetUserList_ShouldReturnList_Service_Test()
        {
            //Arrange
            List<User> users = new List<User>();
            users.Add(new User
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            });

            _mock.Setup(p => p.GetUsers()).ReturnsAsync(users);

            //Act
            var result = await userService.GetUsers();

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task UpdateUserData_ShouldUpdateData_Service_Test()
        {
            //Arrange      

            RsnDigitalApi.Models.User userModel = new RsnDigitalApi.Models.User
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            _mock.Setup(p => p.UpdateUser(It.IsAny<User>())).ReturnsAsync(true);

            //Act
            var result = await userService.UpdateUser(userModel);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUserData_ShouldDeleteData_Service_Test()
        {
            //Arrange      
            int id = 1;

            _mock.Setup(p => p.DeleteUser(It.IsAny<int>())).ReturnsAsync(true);

            //Act
            var result = await userService.DeleteUser(id);

            //Assert
            Assert.True(result);
        }
    }
}
