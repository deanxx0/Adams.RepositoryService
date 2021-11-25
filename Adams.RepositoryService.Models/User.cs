using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserClaim { get; set; }
        [Required]
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
