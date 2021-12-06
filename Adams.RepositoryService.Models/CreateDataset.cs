using NAVIAIServices.RepositoryService.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateDataset
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DatasetTypes Type { get; set; }

        public CreateDataset(string name, string description, DatasetTypes type)
        {
            Name = name;
            Description = description;
            Type = type;
        }
        public CreateDataset()
        {

        }
    }
}
