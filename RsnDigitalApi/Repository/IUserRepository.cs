

using RsnDigitalApi.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RsnDigitalApi.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<int> SaveUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> GetUser(int id);
    }
}
