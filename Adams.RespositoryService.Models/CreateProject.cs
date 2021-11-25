using NAVIAIServices.RepositoryService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RespositoryService.Models
{
    public class CreateProject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string AIType { get; set; }

        public CreateProject(string name, string description, string aitype)
        {
            this.Name = name;
            this.Description = description;
            this.AIType = aitype;
        }

        public CreateProject()
        {

        }
    }
}
