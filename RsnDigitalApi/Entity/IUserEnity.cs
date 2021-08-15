using RsnDigitalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsnDigitalApi.Entity
{
   public interface IUserEnity
    {
        List<Users> GetUser();
        public List<Users> GetUserList { get; set; }
    }
}
