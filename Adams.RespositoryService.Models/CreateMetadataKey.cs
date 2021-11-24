using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RespositoryService.Models
{
    public class CreateMetadataKey
    {
        public string Type { get; set; }
        public string Key { get; set; }
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
