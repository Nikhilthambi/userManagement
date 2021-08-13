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
        private readonly UserController UserController;
        private readonly Mock<IUserService> _mock = new Mock<IUserService>();
        public UserCotrollerTest()
        {
            UserController = new UserController(_mock.Object);
        }

        [Fact]
        public async Task UserList_ShouldReturnList_Controller_Test()
        {
            //Arrange
            List<UserModel> list = new List<UserModel>();
            list.Add(new UserModel
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            });

            _mock.Setup(p => p.Users()).ReturnsAsync(list);

            //Act
            var result = await UserController.Get();
            var okResult = result as OkObjectResult;
            var okResultData = okResult.Value as List<UserModel>;

            //Assert
            Assert.Equal(200, okResult.StatusCode);
            Assert.True(okResultData.Count > 0);
        }

        [Fact]
        public async Task CreateUser_ShouldInsert_Controller_Test()
        {
            //Arrange
            UserModel model = new UserModel
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            _mock.Setup(p => p.SaveUser(model)).ReturnsAsync(true);

            //Act
            var result = await UserController.Post(model);
            var okResult = result as OkObjectResult;
            // var okResultData = okResult.Value as MyProperty;

            //Assert
            Assert.Equal(200, okResult.StatusCode);
            //Assert.True(okResultData);
        }

        [Fact]
        public async Task UpdateUser_ShouldUpdate_Controller_Test()
        {
            //Arrange
            UserModel model = new UserModel
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            _mock.Setup(p => p.SaveUser(model)).ReturnsAsync(true);

            //Act
            var result = await UserController.Post(model);
            var okResult = result as OkObjectResult;
            // var okResultData = okResult.Value as MyProperty;

            //Assert
            Assert.Equal(200, okResult.StatusCode);
            //Assert.True(okResultData);
        }

        [Fact]
        public async Task DeleteUser_ShouldDelete_Controller_Test()
        {
            

            _mock.Setup(p => p.SaveUser(1)).ReturnsAsync(true);

            //Act
            var result = await UserController.delete(model);
            var okResult = result as OkObjectResult;
            // var okResultData = okResult.Value as MyProperty;

            //Assert
            Assert.Equal(200, okResult.StatusCode);
            //Assert.True(okResultData);
        }
    }
}
