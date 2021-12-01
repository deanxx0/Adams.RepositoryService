using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IProjectClient
    {
        IClassInfoClient ClassInfos { get; }
        IInputChannelClient InputChannels { get; }
        IMetadataKeyClient MetadataKeys { get; }
        ITrainConfigurationClient TrainConfigurations { get; }
        IAugmentationClient Augmentations { get; }
        IDatasetClient Datasets { get; }
        IItemClient Items { get; }
    }
}
