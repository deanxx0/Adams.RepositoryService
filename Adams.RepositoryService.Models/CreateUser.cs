using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserClaim { get; set; }

        public CreateUser()
        {

        }

        public CreateUser(string userName, string password, string userClaim)
        {
            UserName = userName;
            Password = password;
            UserClaim = userClaim;
        }
    }
}
