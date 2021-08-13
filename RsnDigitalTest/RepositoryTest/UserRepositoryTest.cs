using System.Threading.Tasks;
using Xunit;
using System;

namespace UserDetectionTest.RepositoryTest
{
    public class UserRepositoryTest
    {
        private UserRepository userRepository;

        [Fact]
        public async Task GetUserList_ShouldReturnList_RepoTest()
        {
            //Arrange
            Init();

            //Act
            var result = await UserRepository.Users();

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task CreateUser_ShouldInsert_RepoTest()
        {
            //Arrange
            Init();
            var data = new User
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            //Act
            var result = await UserRepository.CreateUser(data);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task UpdateUser_ShouldUpdate_RepoTest()
        {
            //Arrange
            Init();
            var data = new User
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            //Act
            var result = await UserRepository.SaveUser(data);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_ShouldDelete_RepoTest()
        {
            //Arrange
            Init();
            var data = new User
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            //Act
            var result = await UserRepository.DeleteUser(data);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ValidateUser_ShouldValidate_RepoTest()
        {
            //Arrange
            Init();
            var data = new User
            {
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            //Act
            var result = await UserRepository.ValidateUser(data);

            //Assert
            Assert.True(result);
        }
    }
}
