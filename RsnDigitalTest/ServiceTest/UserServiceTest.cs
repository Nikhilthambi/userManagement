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

            _mock.Setup(p => p.users()).ReturnsAsync(users);

            //Act
            var result = await userService.Users();

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task UpdateUserData_ShouldUpdateData_Service_Test()
        {
            //Arrange      

            UserModel userModel = new UserModel
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            _mock.Setup(p => p.UpdateUser(It.IsAny<User>())).ReturnsAsync(true);

            //Act
            var result = await userService.UpdateUser(Usermodel);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUserData_ShouldDeleteData_Service_Test()
        {
            //Arrange      
            int id = 1;

            _mock.Setup(p => p.DeleteUser(id).ReturnsAsync(true);

            //Act
            var result = await userService.DeleteUser(Usermodel);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ValidateUserData_ShouldValidateData_Service_Test()
        {
            //Arrange      
            int id = 1;

            _mock.Setup(p => p.ValidateUser(id).ReturnsAsync(true);

            //Act
            var result = await userService.ValidateUser(Usermodel);

            //Assert
            Assert.True(result);
        }
    }
}
