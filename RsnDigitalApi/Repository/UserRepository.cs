using Microsoft.EntityFrameworkCore;
using RsnDigitalApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsnDigitalApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext dbContext;
        public UserRepository(DatabaseContext _databaseContext) => dbContext = _databaseContext;

        public async Task<bool> DeleteUser(int id)
        {
            var data = dbContext.Users.Find(id);
            if (data != null)
            {
                dbContext.Remove(data);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User> GetUser(int id)
        {
            var data = await dbContext.Users.Where(x => x.UserID == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<User>> GetUsers()
        {
            var data =await dbContext.Users.ToListAsync();
            return data;
        }

        public async Task<int> SaveUser(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user.UserID;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var data = dbContext.Users.Find(user.UserID);
            if (data != null)
            {
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.DOB = user.DOB;
                dbContext.Attach(data);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
