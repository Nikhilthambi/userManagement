using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RsnDigitalApi.Models;
using RsnDigitalApi.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RsnDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private const string UserName = "Nikhil@gmail.com";
        private const string Password = "Nikhil123";
        private const int UserId = 100;
        private readonly IConfiguration _configuration;
        public UserController(IUserService _userService, IConfiguration configuration)
        {
            userService = _userService;
            _configuration = configuration;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await userService.GetUsers();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ret = await userService.GetUser(id);
            return Ok(ret);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User data)
        {
            var ret = await userService.SaveUser(data);
            return Ok(ret);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User value)
        {
            //User user = new User { UserID = 0, DOB = DateTime.Parse(value.DOB), FirstName = value.FirstName, LastName = value.LastName };
            var data = await userService.UpdateUser(value);
            return Ok(data);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await userService.DeleteUser(id);
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost("UserValidation")]
        public async Task<IActionResult> Get([FromBody] UserModel data)
        {
            
            if (data != null && data.UserName == UserName && data.Password == Password)
            {
                data.Password = null;
                data.UserName = UserName;
                data.Email = UserName;
                data.UserID = UserId;
                var tokenHandler = new JwtSecurityTokenHandler();

                //add private key 
                string secretKey = _configuration["JwtConfig:Secret"];
                var key = Encoding.ASCII.GetBytes(secretKey);

                //add tokenDescriptor for secure toke
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name,UserName),
                        new Claim("UserID",UserId.ToString()),
                         //new Claim(ClaimTypes.Email,data.Email.ToString()),
                         new Claim(ClaimTypes.Version,"5.0"),
                    }),
                    //added expiry
                    Expires = DateTime.Now.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                //create token from tokenDescriptor
                var tokenKey = tokenHandler.CreateToken(tokenDescriptor);
                //create token from tokenDescriptor
                data.Token = tokenHandler.WriteToken(tokenKey);
            }
            else
            {
                data.Email = null;
                data.Password = null;
            }
            return Ok(data);
        }
    }
}
