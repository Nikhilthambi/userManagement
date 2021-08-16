using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsnDigitalApi.Models
{
    public class UserRequest
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
    }
}
