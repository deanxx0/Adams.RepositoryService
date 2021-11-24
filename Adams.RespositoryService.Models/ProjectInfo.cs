using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RespositoryService.Models
{
    public class ProjectInfo
    {
        public string Id { get; set; }
        public string EntityId { get; set; }
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
