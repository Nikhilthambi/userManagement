using RsnDigitalApi.Models;
using RsnDigitalApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsnDigitalApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository) => userRepository = _userRepository;

        public async Task<bool> DeleteUser(int id)
        {
            return await userRepository.DeleteUser(id);
        }

        public async Task<User> GetUser(int id)
        {
            var data = await userRepository.GetUser(id);
            if (data != null)
            {
                User user = new User { DOB = data.DOB, FirstName = data.FirstName, UserID = data.UserID, LastName = data.LastName };
                return user;
            }
            return new User();
        }

        public async Task<List<User>> GetUsers()
        {
            var data = await userRepository.GetUsers();
            return data.Select(c =>
                new User
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DOB = c.DOB,
                    UserID = c.UserID
                }).ToList();
        }

        public async Task<int> SaveUser(User user)
        {
            Entity.User user1 = new Entity.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                UserID = 0
            };
            return await userRepository.SaveUser(user1);
        }

        public async Task<bool> UpdateUser(User user)
        {
            Entity.User user1 = new Entity.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                UserID = user.UserID
            };
            return await userRepository.UpdateUser(user1);
        }
    }
}
