using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateMetadataValue
    {
        [Required]
        public string KeyId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Value { get; set; }

        public CreateMetadataValue(string keyId, string type, string value)
        {
            KeyId = keyId;
            Type = type;
            Value = value;
        }

        public CreateMetadataValue()
        {

        }
    }
}
