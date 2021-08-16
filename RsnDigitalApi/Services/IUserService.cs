using RsnDigitalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsnDigitalApi.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<int> SaveUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> GetUser(int id);
    }
}
