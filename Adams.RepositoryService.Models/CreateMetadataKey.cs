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
        public string Type { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public string Description { get; set; }

        public CreateMetadataKey(string key, string description, string type)
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
