using Adams.RespositoryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Server.Controllers
{
    [ApiController]
    [Route("")]
    [Authorize(Policy = PolicyNames.AdminOnly)]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("users")]
        public ActionResult CreateUser(CreateUser createUser)
        {
            var hasher = new PasswordHasher<string>();
            var hashedStr = hasher.HashPassword(createUser.UserName, createUser.Password);

            var user = new User(
                createUser.UserName,
                hashedStr,
                createUser.UserClaim
                );
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return Ok(user);
        }

        [HttpGet("users")]
        public ActionResult<List<User>> GetAllUser()
        {
            var users = _appDbContext.Users.AsQueryable().ToList();
            return Ok(users);
        }

        [HttpGet("users/{username}")]
        public ActionResult GetUser(string username)
        {
            var user = _appDbContext.Users.AsQueryable().Where(x => x.UserName == username).FirstOrDefault();
            return Ok(user);
        }

        [HttpDelete("users/{username}")]
        public ActionResult DeleteUser(string username)
        {
            var user = _appDbContext.Users.AsQueryable().Where(x => x.UserName == username).FirstOrDefault();
            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChanges();
            return Ok();
        }
    }
}
