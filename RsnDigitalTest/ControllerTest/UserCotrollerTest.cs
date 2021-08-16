using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using RsnDigitalApi;
using RsnDigitalApi.Controllers;
using RsnDigitalApi.Helper;
using RsnDigitalApi.Models;
using RsnDigitalApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace UserDetectionTest.ControllerTest
{
    public class UserCotrollerTest
    {
        private readonly UserController userController;
        private readonly Mock<IUserService> _mock = new Mock<IUserService>();
        private readonly IOptions<AppSettings> _options = Options.Create(new AppSettings());
        public UserCotrollerTest()
        {
            userController = new UserController(_mock.Object, _options);
        }

        [Fact]
        public async Task UserList_ShouldReturnList_Controller_Test()
        {
            //Arrange
            List<User> list = new List<User>();
            list.Add(new User
            {
                UserID = 1,
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            }); ;

            _mock.Setup(p => p.GetUsers()).ReturnsAsync(list);

            //Act
            var result = await userController.Get();
            var okResult = result as OkObjectResult;
            var okResultData = okResult.Value as List<User>;

            //Assert
            Assert.Equal(200, okResult.StatusCode);
            Assert.True(okResultData.Count > 0);
        }

        [Fact]
        public async Task CreateUser_ShouldInsert_Controller_Test()
        {
            //Arrange
            int id = 1;
            User model = new User
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            _mock.Setup(p => p.SaveUser(It.IsAny<User>())).ReturnsAsync(1);

            //Act
            var result = await userController.Post(model);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task UpdateUser_ShouldUpdate_Controller_Test()
        {
            //Arrange
            User model = new User
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            _mock.Setup(p => p.UpdateUser(It.IsAny<User>())).ReturnsAsync(true);

            //Act
            var result = await userController.Post(model);
            var okResult = result as OkObjectResult;
            var okResultData = okResult.Value as User;

            //Assert
            Assert.Equal(200, okResult.StatusCode);
            //Assert.True(okResultData);
        }

        [Fact]
        public async Task DeleteUser_ShouldDelete_Controller_Test()
        {


            _mock.Setup(p => p.DeleteUser(1)).ReturnsAsync(true);

            //Act
            var result = await userController.Delete(1);
            var okResult = result as OkObjectResult;
             var okResultData = okResult.Value as User;

            //Assert
            Assert.Equal(200, okResult.StatusCode);
            //Assert.True(okResultData);
        }
    }
}
