using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateTrain
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConfigurationId { get; init; }
        public string AugmentationId { get; init; }
        public List<string> TrainSetIdList { get; init; }
        public List<string> ValidationSetIdList { get; init; }

        public CreateTrain()
        {

        }
    }
}
