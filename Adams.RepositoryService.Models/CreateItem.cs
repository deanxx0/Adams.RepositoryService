using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateItem
    {
        [Required]
        public string Tag { get; set; }

        public CreateItem(string tag)
        {
            Tag = tag;
        }

        public CreateItem()
        {

        }
    }
}
