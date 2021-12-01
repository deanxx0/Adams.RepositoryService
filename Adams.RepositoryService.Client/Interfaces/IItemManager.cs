using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IItemManager
    {
        IImageInfoClient ImageInfos { get; }
        IMetadataValueClient MetadataValues { get; }
    }
}
