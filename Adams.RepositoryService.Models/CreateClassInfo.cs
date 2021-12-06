using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateClassInfo
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public byte R { get; set; }
        [Required]
        public byte G { get; set; }
        [Required]
        public byte B { get; set; }
        [Required]
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
