using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client
{
    public class ProjectService : IProjectService
    {
        public ProjectService(string projectId)
        {
        }
        public bool IsMultiChannel => throw new NotImplementedException();

        public Project Entity => throw new NotImplementedException();

        public IClassInfoService ClassInfos => throw new NotImplementedException();

        public IDatasetService Datasets => throw new NotImplementedException();

        public IInputChannelService InputChannels => throw new NotImplementedException();

        public IItemService Items => throw new NotImplementedException();

        public IMetadataValueService MetadataValues => throw new NotImplementedException();

        public IMetadataKeyService MetadataKeys => throw new NotImplementedException();

        public IImageInfoService ImageInfos => throw new NotImplementedException();

        public ITrainConfigurationService TrainConfigurations => throw new NotImplementedException();

        public ITrainService Trains => throw new NotImplementedException();

        public IAugmentationService Augmentations => throw new NotImplementedException();

        public bool BeginTrans()
        {
            throw new NotImplementedException();
        }

        public void CommitTrans()
        {
            throw new NotImplementedException();
        }
    }
}
