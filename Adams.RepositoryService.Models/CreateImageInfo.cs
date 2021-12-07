using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateImageInfo
    {
        [Required]
        public string ChannelId { get; set; }
        //[Required]
        //public string StorageType { get; set; }
        //[Required]
        //public string CopyTypes { get; set; }
        [Required]
        public string OriginalFilePath { get; set; }

        public CreateImageInfo(string channelId, string origianlPath)//, string storageType, string copyType, string origianlPath)
        {
            ChannelId = channelId;
            OriginalFilePath = origianlPath;
            //StorageType = storageType;
            //CopyTypes = copyType;
            //OriginalFilePath = origianlPath;
        }

        public CreateImageInfo()
        {

        }
    }
}
