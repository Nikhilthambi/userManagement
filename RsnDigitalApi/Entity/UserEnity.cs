using RsnDigitalApi.Models;
using System;
using System.Collections.Generic;

namespace RsnDigitalApi.Entity
{
    public class UserEnity : IUserEnity
    {
        public List<Users> GetUserList { get; set; }

        public List<Users> GetUser()
        {
            throw new NotImplementedException();
        }
    }
}
