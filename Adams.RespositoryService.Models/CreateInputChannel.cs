using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RespositoryService.Models
{
    public class CreateInputChannel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsColor { get; set; }
        public string NamingRegex { get; set; }
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
