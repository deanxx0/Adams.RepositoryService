using NAVIAIServices.RepositoryService.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateProject
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
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
