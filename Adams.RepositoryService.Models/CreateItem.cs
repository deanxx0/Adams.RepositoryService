using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateItem
    {
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
