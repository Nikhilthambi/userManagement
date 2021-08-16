using System.Threading.Tasks;
using Xunit;
using System;
using Microsoft.EntityFrameworkCore;
using RsnDigitalApi.Entity;
using RsnDigitalApi.Repository;

namespace UserDetectionTest.RepositoryTest
{
    public class UserRepositoryTest
    {
        private UserRepository userRepository;
        public void Init()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "HelloFreshDB1").Options;
            DatabaseContext context = new DatabaseContext(options);
            context.Database.EnsureDeleted();
            context.Users.Add(new User
            {
                FirstName = "Windows1",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            });
            context.Users.Add(new User
            {
                FirstName = "Windows2",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            });
            context.SaveChanges();
            userRepository = new UserRepository(context);
        }
        [Fact]
        public async Task GetUserList_ShouldReturnList_RepoTest()
        {
            //Arrange
            Init();

            //Act
            var result = await userRepository.GetUsers();

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
            var result = await userRepository.SaveUser(data);

            //Assert
            Assert.True(result>0);
        }

        [Fact]
        public async Task UpdateUser_ShouldUpdate_RepoTest()
        {
            //Arrange
            Init();
            var data = new User
            {
                UserID=1,
                FirstName = "Windows",
                LastName = "Chrome",
                DOB = DateTime.Parse("Jan 1, 2009")
            };

            //Act
            var result = await userRepository.UpdateUser(data);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_ShouldDelete_RepoTest()
        {
            //Arrange
            Init();         

            //Act
            var result = await userRepository.DeleteUser(1);

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
            var result = await userRepository.GetUser(1);

            //Assert
            Assert.True(result.UserID>0);
        }
    }
}
