using NAVIAIServices.RepositoryService.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateMetadataKey
    {
        [Required]
        public MetadataTypes Type { get; set; }
        //public string Type { get; set; }
        [Required]
        public string Key { get; set; }
        public string Description { get; set; }

        //public CreateMetadataKey(string key, string description, string type)
        public CreateMetadataKey(string key, string description, MetadataTypes type)
        {
            this.Key = key;
            this.Type = type;
            this.Description = description;
        }

        public CreateMetadataKey()
        {

        }
    }
}
