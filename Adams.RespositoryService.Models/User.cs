using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RespositoryService.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserClaim { get; set; }
        public DateTime CreatedAt { get; set; }

        public User()
        {

        }

        public User(string userName, string password, string userClaim)
        {
            Id = Guid.NewGuid().ToString();
            UserName = userName;
            Password = password;
            UserClaim = userClaim;
            CreatedAt = DateTime.Now;
        }
    }
}
