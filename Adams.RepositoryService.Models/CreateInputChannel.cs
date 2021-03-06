using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateInputChannel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsColor { get; set; }
        public string NamingRegex { get; set; }
        [Required]
        public bool IsEnabled { get; set; }

        public CreateInputChannel(string name, bool isColor, string description, string namingRegex)
        {
            this.Name = name;
            this.IsColor = isColor;
            this.Description = description;
            this.NamingRegex = namingRegex;
        }
        public CreateInputChannel()
        {

        }
    }
}
