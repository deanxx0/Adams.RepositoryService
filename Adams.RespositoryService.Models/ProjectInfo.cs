using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RespositoryService.Models
{
    public class ProjectInfo
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string EntityId { get; set; }
        [Required]
        public string DbPath { get; set; }

        public ProjectInfo()
        {

        }

        public ProjectInfo(string entityId, string dbpath)
        {
            this.Id = Guid.NewGuid().ToString();
            this.EntityId = entityId;
            this.DbPath = dbpath;

        }
    }
}
