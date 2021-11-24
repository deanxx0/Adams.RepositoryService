using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RespositoryService.Models
{
    public class CreateClassInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public bool IsEnabled { get; set; }

        public CreateClassInfo(string name, string Description, byte R, byte G, byte B)
        {
            this.Name = name;
            this.Description = Description;
            this.R = R;
            this.G = G;
            this.B = B;
        }

        public CreateClassInfo()
        {

        }
    }
}
